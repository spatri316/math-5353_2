// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

// Your assignment - due in two weeks - is to implement antithetic variance
// reduction and Van der Corput sequences in your C# Monte Carlo
// simulator. Antithetic should exhibit the following features.
// Allow the user to apply antithetic, or not
// Apply antithetic when calculating option price
// Apply antithetic when calculation option Greeks
// Produce a correct standard error under both antithetic and
// non-antithetic circumstances
// The Van der Corput functionality will be special. It need only exist in one
// dimension (one step), and it may use a fixed number of simulations, as in
// our example. The user must be able to enter the base values for the
// simulation. Option price and Greeks - but not standard error - needs to be
// returned to the user.

namespace MyApp
{
    class Program{

        static void Main(string[] args) {
            // Try and Catch Block to make sure we only get numeric values for steps and simulation
            Console.WriteLine("Change bool call on line 65 to represent call or put. Other variables can be changed from line 59 to 63");
            Console.WriteLine("Do you want antithetic calculation? Type yes, otherwise no");
            String antithetic_user_input = Console.ReadLine();
            String antithetic_user_input_yes = "yes";
            bool antithetic = String.Equals(antithetic_user_input, antithetic_user_input_yes);

            Console.WriteLine("Do you want to delta-based control variate functionality? Type yes, otherwise no");
            String control_user_input = Console.ReadLine();
            String control_user_input_yes = "yes";
            bool control_variate = String.Equals(control_user_input, control_user_input_yes);

            Console.WriteLine("Do you want to delta-based control variate functionality along with antithetic? Type yes, otherwise no");
            String control_user_anti_input = Console.ReadLine();
            String control_user_anti_input_yes = "yes";
            bool control_variate_antithetic = String.Equals(control_user_anti_input, control_user_anti_input_yes);

            Console.WriteLine("Provide a choice in number of steps: ");
            String steps = Console.ReadLine();
            int steps_double = 1;

            Console.WriteLine("Provide a choice in number of simulations: ");
            String simulations = Console.ReadLine();
            int simulations_double = 1;
    
            try {
                steps_double = Convert.ToInt32(steps);
                simulations_double = Convert.ToInt32(simulations);
            }
            catch (FormatException) {
                Console.WriteLine("Enter a numeric value");
                return;
            }


            // Change the variables here
            double s=50;
            double r=0.05;
            double v=0.5;
            double t=1;
            double strike = 50;
            //change this for call/put. call = true, put = false
            bool call = false;

            // Call and populate the array for random normal paths
            NormalRandomPaths nrp1 = new NormalRandomPaths();
            double[,] random_normal_paths = nrp1.fillRandomPaths(steps_double, simulations_double);

            SimulatedPaths sp1 = new SimulatedPaths();
            double[] simulated_paths = new double[simulations_double];
            double final_value = 0;
            double[] control_variate_value_array = new double[simulations_double];
            double control_variate_value = 0;

            //STANDARD ERROR
            StandardError std_err = new StandardError();

            //antithetic
            if(antithetic) {
                Console.WriteLine("Antithetic");
                simulated_paths = sp1.AntitheticFinalCalculation(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths);
                final_value = sp1.finalMean(r,t,simulated_paths);
                double standard_error_antithetic = std_err.standard_error(simulated_paths);
                double[] simulated_paths_non_antithetic = sp1.SimulatedPathsCalculation(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths);
                double standard_error_not_antithetic = std_err.standard_error(simulated_paths_non_antithetic);

                Console.WriteLine("Option Antithetic price is: "+final_value);
                Console.WriteLine("Standard error with antithetic is "+ standard_error_antithetic);
                Console.WriteLine("Standard error without antithetic is "+ standard_error_not_antithetic);
            }

            else if(control_variate) {
                Console.WriteLine("Control Variate");
                ControlVariate stv = new ControlVariate();
                control_variate_value_array = stv.delta_based_call_old_way(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths);
                final_value = sp1.finalMean(r,t,control_variate_value_array);
                Console.WriteLine("Control Variate Price: "+ final_value);
                double standard_error = std_err.standard_error(control_variate_value_array);
                Console.WriteLine("Standard error with control variate is "+ standard_error);
                // Console.WriteLine("Standard error without antithetic is "+ standard_error_not_antithetic);
            }

            else if(control_variate_antithetic) {
                Console.WriteLine("Control Variate Antithetic");
                ControlVariate stv = new ControlVariate();
                control_variate_value_array = stv.delta_antithetic(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths);
                final_value = sp1.finalMean(r,t,control_variate_value_array);
                Console.WriteLine("Control Variate Antithetic Price: "+ final_value);
                double standard_error = std_err.standard_error(control_variate_value_array);
                Console.WriteLine("Standard error with control variate is "+ standard_error);
                // Console.WriteLine("Standard error without antithetic is "+ standard_error_not_antithetic);
            }

            else {
                // get the Option prices of the simulations. (the last step of each simulation)
                simulated_paths = sp1.SimulatedPathsCalculation(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths);
                //calulate the final calculation by taking a mean of all the option prices and multiply with e^-rt
                final_value = sp1.finalMean(r,  t, simulated_paths);
                double standard_error = std_err.standard_error(simulated_paths);
                Console.WriteLine("Option price is: "+final_value);
                Console.WriteLine("Standard error is "+ standard_error);
            } 

            // THIS SECTION CALLS THE GREEK CLASS FOR EITHER THE ANTITHETIC OR NON ANTITHETIC
            //DELTA
            Greeks greek_methods = new Greeks();
            double delta = greek_methods.delta(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, antithetic, control_variate, control_variate_antithetic);
            Console.WriteLine("Delta is "+delta);

            //GAMMA
            double gamma = greek_methods.gamma(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, final_value, antithetic, control_variate, control_variate_antithetic);
            Console.WriteLine("Gamma is "+gamma);

            //VEGA
            double vega = greek_methods.vega(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, antithetic, control_variate, control_variate_antithetic);
            Console.WriteLine("Vega is "+vega);

            //THETA
            double theta = greek_methods.theta(s, r, v,  t, steps_double, simulations_double, call, strike, random_normal_paths, final_value, antithetic, control_variate, control_variate_antithetic);
            Console.WriteLine("Theta is "+theta);

            //RHO
            double rho = greek_methods.rho(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, antithetic, control_variate, control_variate_antithetic);
            Console.WriteLine("Rho is "+rho);

        }
    }

    // SIMULATED PATHS - CALCULATE OPTION PRICES BASED ON CALL OR PUT AND GET THE FINAL OPTION PRICE OF ALL THE PATHS
    public class SimulatedPaths{

        //TAKE NORMAL RANDOM PATHS AND GET THE CALCUALTION. STORE THE LAST STEP OF EACH SIMULATION AND RETURN AN ARRAY OF ALL THE VALUES
        public double[] SimulatedPathsCalculation(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths){
            
            //variables
            double[,] stock_values = new double[simulation, steps];
            double[,] SimulatedPaths = new double[simulation, steps];
            double subtraction = 0;
            double path_val = 0;

            for(int i = 0; i < simulation; i++){
                for(int j = 0; j < steps; j++){
                    stock_values[i, 0] = s;
                }
            }    

            // double for loop to go over each step in every simulation and apply the payoff function
            // A double array is filled in this for loop
            for(int i = 0; i < simulation; i++){
                for(int j = 1; j < steps; j++){
                    //formula
                    double steps_calc = t/steps;
                    double value = stock_values[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                    stock_values[i, j] = value;
                    //calls
                    if(call == true){
                        subtraction = value - strike;
                        path_val = Math.Max(subtraction, 0);
                    }
                    //puts
                    else{
                        subtraction =  strike - value;
                        path_val = Math.Max(subtraction, 0);
                    }
                    SimulatedPaths[i,j] = path_val;
                }
            }
            
            // this for loop retrieves the last value of each step and returns the single dimension array
            double[] end_values = new double[SimulatedPaths.GetLength(0)];
            for(int i = 0; i < SimulatedPaths.GetLength(0); i++){
                end_values[i] = SimulatedPaths[i, (SimulatedPaths.GetLength(1)-1)];
            }
            return end_values;
        }


        // do the average of all the option prices and get ONE PRICE for all simulations
        public double finalMean(double r, double t, double[] SimulatedPaths){

            double final_mean = 0;
            double average = 0;

            //sum
            for(int i = 0; i < SimulatedPaths.Length; i++){
                average += SimulatedPaths[i];
            }
            //average
            average = average/SimulatedPaths.Length;
            //final formula
            final_mean = Math.Exp(-r * t) * average;
        
            return final_mean;
        }

        // Antithetic Calculation with negative random normal values
        public double[] AntitheticFinalCalculation(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths) {
            double[,] antithetic_random_normal = new double[random_normal_paths.GetLength(0), random_normal_paths.GetLength(1)];

            // get the random normal values - multiply with -1
            for(int i = 0; i < random_normal_paths.GetLength(0); i++){
                for(int j = 0; j < random_normal_paths.GetLength(1); j++){
                    antithetic_random_normal[i,j] = -1*random_normal_paths[i,j];
                }
            }

            // get the option prices for both random normal values
            double[] e = SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,random_normal_paths);
            double[] e_hat = SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,antithetic_random_normal);

            double[] simulated_antithethic_paths = new double[e.Length];
            
            // average of both
            for(int i = 0; i < e.Length; i++) {
                simulated_antithethic_paths[i] = (e[i] + e_hat[i])/2;
            }

            return simulated_antithethic_paths;
        }

    }


    // CLASS FOR ALL THE GREEKS - DELTA, GAMMA, THETA, VEGA, RHO
    public class Greeks {
        
        // DELTA
        public double delta(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool antithetic, bool control_variate, bool control_variate_antithetic){
            
            // DELTA S CONSIDERATION
            double s_plus = s + 0.001;
            double s_minus = s - 0.001;
            double delta = 0;

            if(antithetic) {
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.AntitheticFinalCalculation(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = path1.AntitheticFinalCalculation(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                
                //FINAL FORMULA
                delta = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else if(control_variate) {
                ControlVariate ctr = new ControlVariate();
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = ctr.delta_based_call_old_way(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_based_call_old_way(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                
                //FINAL FORMULA
                delta = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else if(control_variate_antithetic) {
                ControlVariate ctr = new ControlVariate();
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = ctr.delta_antithetic(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_antithetic(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                
                //FINAL FORMULA
                delta = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else{
                 //GET SIMULATED PATHS WITH S_PLUS AND S_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.SimulatedPathsCalculation(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = path1.SimulatedPathsCalculation(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                
                //FINAL FORMULA
                delta = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            return delta;
        }

        //GAMMA
        public double gamma(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, double final_value, bool antithetic, bool control_variate, bool control_variate_antithetic){
            
            // GAMMA S CONSIDERATION
            double s_plus = s + 0.001*s;
            double s_minus = s - 0.001*s;
            double gamma = 0;

            if(antithetic) {
                // GET SIMULATED PATHS WITH S_PLUS AND S_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.AntitheticFinalCalculation(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = path1.AntitheticFinalCalculation(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                gamma = (final_mean_plus + final_mean_minus - 2*final_value)/(Math.Pow((0.001*s),2));

            }
            else if(control_variate) {
                // GET SIMULATED PATHS WITH S_PLUS AND S_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_based_call_old_way(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_based_call_old_way(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                gamma = (final_mean_plus + final_mean_minus - 2*final_value)/(Math.Pow((0.001*s),2));

            }

            else if(control_variate_antithetic) {
                // GET SIMULATED PATHS WITH S_PLUS AND S_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_antithetic(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_antithetic(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                gamma = (final_mean_plus + final_mean_minus - 2*final_value)/(Math.Pow((0.001*s),2));

            }

            else{
                // GET SIMULATED PATHS WITH S_PLUS AND S_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.SimulatedPathsCalculation(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = path1.SimulatedPathsCalculation(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);

                gamma = (final_mean_plus + final_mean_minus - 2*final_value)/(Math.Pow((0.001*s),2));

            }
            return gamma;
        }

        //VEGA
        public double vega(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool antithetic, bool control_variate, bool control_variate_antithetic){
            
            // VEGA SIGMA CONSIDERATION
            double v_plus = v + 0.001;
            double v_minus = v - 0.001;
            double vega = 0;

            if(antithetic){
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.AntitheticFinalCalculation(s, r, v_plus, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = path1.AntitheticFinalCalculation(s, r, v_minus, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);

                //FINAL FORMULA
                vega = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else if(control_variate){
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_based_call_old_way(s, r, v_plus, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_based_call_old_way(s, r, v_minus, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);

                //FINAL FORMULA
                vega = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else if(control_variate_antithetic){
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_antithetic(s, r, v_plus, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_antithetic(s, r, v_minus, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);

                //FINAL FORMULA
                vega = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else {
                // GET SIMULATED PATHS WITH V_PLUS AND V_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.SimulatedPathsCalculation(s, r, v_plus, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = path1.SimulatedPathsCalculation(s, r, v_minus, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);

                //FINAL FORMULA
                vega = (final_mean_plus - final_mean_minus)/(2*0.001);
            }
            return vega;
        }

        // THETA
        public double theta(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, double final_value, bool antithetic, bool control_variate, bool control_variate_antithetic){
            
            // DELTA TIME CONSIDERATION
            double t_plus = t + 0.001*t;
            double theta = 0;

            if(antithetic){

                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.AntitheticFinalCalculation(s, r, v, t_plus, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t_plus, paths_plus);

                //final formula
                theta = (final_mean_plus - final_value)/(0.001*t);

            }

            else if(control_variate){

                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_based_call_old_way(s, r, v, t_plus, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t_plus, paths_plus);

                //final formula
                theta = (final_mean_plus - final_value)/(0.001*t);

            }

             else if(control_variate_antithetic){

                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_antithetic(s, r, v, t_plus, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t_plus, paths_plus);

                //final formula
                theta = (final_mean_plus - final_value)/(0.001*t);

            }

            else{
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.SimulatedPathsCalculation(s, r, v, t_plus, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r, t_plus, paths_plus);

                //final formula
                theta = (final_mean_plus - final_value)/(0.001*t);

            }

            //get simulated paths with t_plus
            

            return theta;
        }

        //RHO
        public double rho(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool antithetic, bool control_variate, bool control_variate_antithetic){
            
            //delta r
            double r_plus = r + 0.1;
            double r_minus = r - 0.1;
            double rho = 0;

            if(antithetic) {
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.AntitheticFinalCalculation(s, r_plus, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r_plus, t, paths_plus);

                double[] paths_minus = path1.AntitheticFinalCalculation(s, r_minus, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r_minus, t, paths_minus);

                // rho formula
                rho = (final_mean_plus - final_mean_minus)/(2*0.1);

            }

            else if(control_variate) {
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_based_call_old_way(s, r_plus, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r_plus, t, paths_plus);

                double[] paths_minus = ctr.delta_based_call_old_way(s, r_minus, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r_minus, t, paths_minus);

                // rho formula
                rho = (final_mean_plus - final_mean_minus)/(2*0.1);

            }

            else if(control_variate_antithetic) {
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_antithetic(s, r_plus, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r_plus, t, paths_plus);

                double[] paths_minus = ctr.delta_antithetic(s, r_minus, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r_minus, t, paths_minus);

                // rho formula
                rho = (final_mean_plus - final_mean_minus)/(2*0.1);

            }

            else{
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.SimulatedPathsCalculation(s, r_plus, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_plus = path1.finalMean(r_plus, t, paths_plus);

                double[] paths_minus = path1.SimulatedPathsCalculation(s, r_minus, v, t, steps, simulation, call, strike, random_normal_paths);
                double final_mean_minus = path1.finalMean(r_minus, t, paths_minus);

                // rho formula
                rho = (final_mean_plus - final_mean_minus)/(2*0.1);

            }
            // simulated paths with different R values
            

            return rho;
        }

    }


    // Class for standard error
    public class StandardError {

        // STEP 1: get average
        // STEP 2: (x[i] - average)^2/(n-1) [S.D.]
        // STEP 3: apply standard error formula
        public double standard_error(double[] simulated_paths) {
            double average = 0;
            double sum_of_squares = 0;
            double standard_deviation = 0;
            double standard_error = 0;

            // STEP 1: get average
            for(int i = 0; i < simulated_paths.Length; i++){
                average += simulated_paths[i];
            }
            average = average/simulated_paths.Length;

            // STEP 2: (x[i] - average)^2/(n-1) [S.D.]
            for(int i = 0; i < simulated_paths.Length; i++){
                sum_of_squares += Math.Pow((simulated_paths[i] - average), 2);
            }
            standard_deviation = Math.Sqrt(sum_of_squares/(simulated_paths.Length - 1));

            // STEP 3: apply standard error formula
            standard_error = standard_deviation/(Math.Sqrt(simulated_paths.Length));

            return standard_error;

        }
    }
    
    // class to generate random normal paths
    public class NormalRandomPaths {
       
       NormalRandom nrm = new NormalRandom();

       // method to fill random paths
       public double[,] fillRandomPaths(int steps, int simulations){
        double[,] gaussian = new double[simulations, steps];
        // fill in random paths
        for(int i = 0; i < simulations; i++){
                for(int j = 0; j < steps; j++){
                    gaussian[i,j] = nrm.polar_rejection();
                }
        }
        return gaussian;
       }
    }
    
    // Class from Project 4 - Using Polar Rejection
    public class NormalRandom{
        
        // Polar Rejection from Project 4
        public double polar_rejection(){
            Random r = new Random();

            //Change Interval from [0,1] to [-1,1]
            double a1 = -1 + (2 * r.NextDouble());
            double a2 = -1 + (2 * r.NextDouble());

            double w = Math.Pow(a1, 2) + Math.Pow(a2, 2);

            // Repeat step until w is greater than 1
            while(w > 1){
                a1 = -1 + (2 * r.NextDouble());
                a2 = -1 + (2 * r.NextDouble());
                w = Math.Pow(a1, 2) + Math.Pow(a2, 2);
            }
            // Math 
            double c = Math.Sqrt(-2*Math.Log(w)/w);

            // Return 1 number
            double z1 = c * a1;

            return z1;

        }

        public double[] box_muller(double[] binary_vandercorput_base1, double[] binary_vandercorput_base2){

            //Random r = new Random();

            double[] values_z1 = new double[binary_vandercorput_base1.Length];
            double[] values_z2 = new double[binary_vandercorput_base1.Length];

            for(int i = 0; i < binary_vandercorput_base1.Length; i++) {
                double a1 = binary_vandercorput_base1[i];
                double a2 = binary_vandercorput_base2[i];

                // Math for the calculation
                double z1 = Math.Sqrt(-2*Math.Log(a1))*Math.Cos(2*Math.PI*a2);
                double z2 = Math.Sqrt(-2*Math.Log(a1))*Math.Sin(2*Math.PI*a2);
                
                //Console.WriteLine("Box_muller z1 value is " + z1);
                //Console.WriteLine("Box_muller z2 values is "+ z2);

                values_z1[i] = z1;
                values_z2[i] = z2;
            }

            //Console.WriteLine("Length 1 is  " + values_z1.Length);
            //Console.WriteLine("Length 2 is  " + values_z2.Length);

            double[] final_random_values = new double[2*binary_vandercorput_base1.Length];
            values_z1.CopyTo(final_random_values, 0);
            values_z2.CopyTo(final_random_values, values_z1.Length);
            

            return final_random_values;

        }


    } 

    public class ControlVariate {
         public double[] delta_based_call_old_way(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths)
        {
            //variables
            double[,] stock_values = new double[simulation, steps];
            double[,] SimulatedPaths = new double[simulation, steps];
            double subtraction = 0;
            double path_val = 0;
            double betal = -1;
            double delta = 0;

            BlackScholes bs = new BlackScholes();
            //NormalRandom nrm = new NormalRandom();

            for(int i = 0; i < simulation; i++){
                for(int j = 0; j < steps; j++){
                    stock_values[i, 0] = s;
                }
            }    

            // double for loop to go over each step in every simulation and apply the payoff function
            // A double array is filled in this for loop
            for(int i = 0; i < simulation; i++){
                double cv = 0;
                for(int j = 1; j < steps; j++){
                    //formula
                    // delta = bs.callDelta(stock_values[i, j-1],r,v,t,strike);
                    // double steps_calc = t/steps;
                    // double value = stock_values[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                    // cv = cv + delta * (value - (stock_values[i, j-1] * Math.Exp(r*steps_calc)));
                    // stock_values[i, j] = value;
                    //calls
                    if(call == true){
                        delta = bs.callDelta(stock_values[i, j-1],r,v,t,strike);
                        double steps_calc = t/steps;
                        double value = stock_values[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                        cv = cv + delta * (value - (stock_values[i, j-1] * Math.Exp(r*steps_calc)));
                        stock_values[i, j] = value;
                        subtraction = value - strike;
                        path_val = Math.Max(subtraction, 0) + (betal*cv);
                    }
                    //puts
                    else{
                        delta = bs.putDelta(stock_values[i, j-1],r,v,t,strike);
                        double steps_calc = t/steps;
                        double value = stock_values[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                        cv = cv + delta * (value - (stock_values[i, j-1] * Math.Exp(r*steps_calc)));
                        stock_values[i, j] = value;
                        subtraction =  strike - value;
                        path_val = Math.Max(subtraction, 0) + (betal*cv);
                    }
                    SimulatedPaths[i,j] = path_val;
                }
            }
            
            // this for loop retrieves the last value of each step and returns the single dimension array
            double[] end_values = new double[SimulatedPaths.GetLength(0)];
            for(int i = 0; i < SimulatedPaths.GetLength(0); i++){
                end_values[i] = SimulatedPaths[i, (SimulatedPaths.GetLength(1)-1)];
            }

            return end_values;
        }

         public double[] delta_antithetic(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths)
        {
            //variables
            double[,] stock_values_1 = new double[simulation, steps];
            double[,] stock_values_2 = new double[simulation, steps];
            double[,] SimulatedPaths = new double[simulation, steps];
            double subtraction1 = 0;
            double subtraction2 = 0;
            double path_val = 0;
            double betal = -1;
            double delta1 = 0;
            double delta2 = 0;

            double[,] antithetic_random_normal = new double[random_normal_paths.GetLength(0), random_normal_paths.GetLength(1)];

            BlackScholes bs = new BlackScholes();
            //NormalRandom nrm = new NormalRandom();

            for(int i = 0; i < simulation; i++){
                for(int j = 0; j < steps; j++){
                    stock_values_1[i, 0] = s;
                }
            }  

            for(int i = 0; i < simulation; i++){
                for(int j = 0; j < steps; j++){
                    stock_values_2[i, 0] = s;
                }
            }   

            // get the random normal values - multiply with -1
            for(int i = 0; i < random_normal_paths.GetLength(0); i++){
                for(int j = 0; j < random_normal_paths.GetLength(1); j++){
                    antithetic_random_normal[i,j] = -1*random_normal_paths[i,j];
                }
            }

            // double for loop to go over each step in every simulation and apply the payoff function
            // A double array is filled in this for loop
            for(int i = 0; i < simulation; i++){
                double cv1 = 0;
                double cv2 = 0;
                for(int j = 1; j < steps; j++){
                    //formula
                    // delta1 = bs.callDelta(stock_values_1[i, j-1],r,v,t,strike);
                    // delta2 = bs.callDelta(stock_values_2[i, j-1],r,v,t,strike);
                    // double steps_calc = t/steps;
                    // double value1 = stock_values_1[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                    // double value2 = stock_values_2[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((antithetic_random_normal[i,j] * v * (Math.Sqrt(steps_calc)))));
                    // cv1 = cv1 + delta1 * (value1 - (stock_values_1[i, j-1] * Math.Exp(r*steps_calc)));
                    // cv2 = cv2 + delta2 * (value2 - (stock_values_2[i, j-1] * Math.Exp(r*steps_calc)));

                    // stock_values_1[i, j] = value1;
                    // stock_values_2[i, j] = value2;
                    //calls
                    if(call == true){
                        delta1 = bs.callDelta(stock_values_1[i, j-1],r,v,t,strike);
                        delta2 = bs.callDelta(stock_values_2[i, j-1],r,v,t,strike);
                        double steps_calc = t/steps;
                        double value1 = stock_values_1[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                        double value2 = stock_values_2[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((antithetic_random_normal[i,j] * v * (Math.Sqrt(steps_calc)))));
                        cv1 = cv1 + delta1 * (value1 - (stock_values_1[i, j-1] * Math.Exp(r*steps_calc)));
                        cv2 = cv2 + delta2 * (value2 - (stock_values_2[i, j-1] * Math.Exp(r*steps_calc)));

                        stock_values_1[i, j] = value1;
                        stock_values_2[i, j] = value2;
                        subtraction1 = value1 - strike;
                        subtraction2 = value2 - strike;
                        path_val = 0.5*(Math.Max(subtraction1, 0) + (betal*cv1) + Math.Max(subtraction2, 0) + (betal*cv2));
                    }
                    //puts
                    else{
                        delta1 = bs.callDelta(stock_values_1[i, j-1],r,v,t,strike);
                        delta2 = bs.callDelta(stock_values_2[i, j-1],r,v,t,strike);
                        double steps_calc = t/steps;
                        double value1 = stock_values_1[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                        double value2 = stock_values_2[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((antithetic_random_normal[i,j] * v * (Math.Sqrt(steps_calc)))));
                        cv1 = cv1 + delta1 * (value1 - (stock_values_1[i, j-1] * Math.Exp(r*steps_calc)));
                        cv2 = cv2 + delta2 * (value2 - (stock_values_2[i, j-1] * Math.Exp(r*steps_calc)));

                        stock_values_1[i, j] = value1;
                        stock_values_2[i, j] = value2;
                        subtraction1 =  strike - value1;
                        subtraction2 =  strike - value2;
                        path_val = 0.5*(Math.Max(subtraction1, 0) + (betal*cv1) + Math.Max(subtraction2, 0) + (betal*cv2));
                    }
                    SimulatedPaths[i,j] = path_val;
                }
            }
            
            // this for loop retrieves the last value of each step and returns the single dimension array
            double[] end_values = new double[SimulatedPaths.GetLength(0)];
            for(int i = 0; i < SimulatedPaths.GetLength(0); i++){
                end_values[i] = SimulatedPaths[i, (SimulatedPaths.GetLength(1)-1)];
            }

            return end_values;
        }

    }

    public class BlackScholes {
        public double d1(double s, double r, double v, double t, double k){
            double d1 = 0;
            d1 = (Math.Log(s / k) + ((r + (Math.Pow(v,2))/2) * t)) / (v * Math.Pow(t, 0.5));
            return d1;
        }

        public double callDelta(double s, double r, double v, double t, double k) {
            double callDelta = 0;
            double d1_call_delta = 0;
            d1_call_delta = d1(s, r, v, t, k);
            callDelta = Gaussian_CDF(d1_call_delta);
            return callDelta;
        }

        public double putDelta(double s, double r, double v, double t, double k) {
            double putDelta = 0;
            double d1_put_delta = 0;
            d1_put_delta = d1(s, r, v, t, k);
            putDelta = Gaussian_CDF(d1_put_delta) - 1;
            return putDelta;
        }

        public static double Gaussian_CDF(double z) 
        {
            double p = 0.3275911;
            double a1 = 0.254829592;
            double a2 = -0.284496736;
            double a3 = 1.421413741;
            double a4 = -1.453152027;
            double a5 = 1.061405429;

            int sign;
            if (z < 0.0)
            {
                sign = -1;
            } else {
                sign = 1; 
            } 

            double x = Math.Abs(z) / Math.Sqrt(2.0);
            double t = 1.0 / (1.0 + p * x);
            double erf = 1.0 - (((((a5 * t + a4) * t) + a3) * t + a2) * t + a1) * t * Math.Exp(-x * x);
            return 0.5 * (1.0 + sign * erf);
        }


    }

}
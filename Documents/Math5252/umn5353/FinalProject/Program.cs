using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using MyApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.ComponentModel.DataAnnotations.Schema;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

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
            
            Console.WriteLine("Select 1 for Asian, 2 for Digital, 3 for Barrier, 4 for Lookback, 5 for Range");
            String exotic = Console.ReadLine();
            String exotic_user_input_asian = "1";
            String exotic_user_input_digital = "2";
            String exotic_user_input_barrier = "3";
            String exotic_user_input_lookback = "4";
            String exotic_user_input_range = "5";
            bool exotic_asian = String.Equals(exotic, exotic_user_input_asian);
            bool exotic_digital = String.Equals(exotic, exotic_user_input_digital);
            bool exotic_barrier = String.Equals(exotic, exotic_user_input_barrier);
            bool exotic_lookback = String.Equals(exotic, exotic_user_input_lookback);
            bool exotic_range = String.Equals(exotic, exotic_user_input_range);

            Console.WriteLine("Select barrier type");
            String exotic_barrier_type = Console.ReadLine();

            Console.WriteLine("Do you want parallel functionality? Type yes, otherwise no");
            String parallel = Console.ReadLine();
            String parallel_user_input_yes = "yes";
            bool parallel_variate = String.Equals(parallel, parallel_user_input_yes);

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
            bool call = true;
            double payout = 100;
            double barrier_level = 55;

            // Call and populate the array for random normal paths
            NormalRandomPaths nrp1 = new NormalRandomPaths();
            double[,] random_normal_paths = nrp1.fillRandomPaths(steps_double, simulations_double);

            SimulatedPaths sp1 = new SimulatedPaths();
            ExoticOptions eo1 = new ExoticOptions();
            double[] end_row = new double[simulations_double];
            double final_value = 0;
            double[] control_variate_value_array = new double[simulations_double];
            double control_variate_value = 0;

            double exotic_option_price = 0;
            //STANDARD ERROR
            StandardError std_err = new StandardError();

            if(antithetic) {
                Console.WriteLine("Antithetic");
                end_row = sp1.AntitheticFinalCalculation(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, parallel_variate);
                final_value = sp1.finalMean(r,t,end_row);
                double standard_error_antithetic = std_err.standard_error(end_row);

                Console.WriteLine("Option Antithetic price is: "+final_value);
                Console.WriteLine("Standard error with antithetic is "+ standard_error_antithetic);
            }

            else if(control_variate) {
                Console.WriteLine("Control Variate");
                ControlVariate stv = new ControlVariate();
                control_variate_value_array = stv.delta_based_call_old_way(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, parallel_variate);
                final_value = sp1.finalMean(r,t,control_variate_value_array);
                Console.WriteLine("Control Variate Price: "+ final_value);
                double standard_error = std_err.standard_error(control_variate_value_array);
                Console.WriteLine("Standard error with control variate is "+ standard_error);
            }

            else if(control_variate_antithetic) {
                Console.WriteLine("Control Variate Antithetic");
                ControlVariate stv = new ControlVariate();
                control_variate_value_array = stv.delta_antithetic(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, parallel_variate);
                final_value = sp1.finalMean(r,t,control_variate_value_array);
                Console.WriteLine("Control Variate Antithetic Price: "+ final_value);
                double standard_error = std_err.standard_error(control_variate_value_array);
                Console.WriteLine("Standard error with control variate is "+ standard_error);
            }

            else {
                if(exotic_asian == true) {
                    exotic_option_price = eo1.Asian(s, r, v, t, steps_double, simulations_double, call, strike,random_normal_paths, parallel_variate);
                    Console.WriteLine("Asian Price is: " + exotic_option_price);
                }
                else if(exotic_digital == true) {
                    exotic_option_price = eo1.Digital(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, parallel_variate, payout);
                    Console.WriteLine("Digital Price is: " + exotic_option_price);
                }
                else if(exotic_barrier == true) {
                    exotic_option_price = eo1.Barrier(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, parallel_variate, barrier_level, exotic_barrier_type);
                    Console.WriteLine("Barrier Price is: " + exotic_option_price);
                }
                else if(exotic_lookback == true) {
                    exotic_option_price = eo1.Lookback(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, parallel_variate);
                    Console.WriteLine("Lookback Price is: " + exotic_option_price);
                }
                else if(exotic_range == true) {
                    exotic_option_price = eo1.Range(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, parallel_variate);
                    Console.WriteLine("Range Price is: " + exotic_option_price);
                }
                var simulated_paths = sp1.SimulatedPathsCalculation(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, parallel_variate);
                end_row = sp1.end_values(simulated_paths.Item1);
                //calulate the final calculation by taking a mean of all the option prices and multiply with e^-rt
                final_value = sp1.finalMean(r,  t, end_row);
                double standard_error = std_err.standard_error(end_row);
                Console.WriteLine("Option price is: "+final_value);
                Console.WriteLine("Standard error is "+ standard_error);
            }
        
            // THIS SECTION CALLS THE GREEK CLASS FOR EITHER THE ANTITHETIC OR NON ANTITHETIC
            //DELTA
            Greeks greek_methods = new Greeks();
            double delta = greek_methods.delta(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, antithetic, control_variate, control_variate_antithetic, parallel_variate);
            Console.WriteLine("Delta is "+delta);

            //GAMMA
            double gamma = greek_methods.gamma(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, final_value, antithetic, control_variate, control_variate_antithetic, parallel_variate);
            Console.WriteLine("Gamma is "+gamma);

            //VEGA
            double vega = greek_methods.vega(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, antithetic, control_variate, control_variate_antithetic, parallel_variate);
            Console.WriteLine("Vega is "+vega);

            //THETA
            double theta = greek_methods.theta(s, r, v,  t, steps_double, simulations_double, call, strike, random_normal_paths, final_value, antithetic, control_variate, control_variate_antithetic, parallel_variate);
            Console.WriteLine("Theta is "+theta);

            //RHO
            double rho = greek_methods.rho(s, r, v, t, steps_double, simulations_double, call, strike, random_normal_paths, antithetic, control_variate, control_variate_antithetic, parallel_variate);
            Console.WriteLine("Rho is "+rho);

            //Console.WriteLine("The number of processors on this computer is {0}.", num_cores);

        }
    }

    public class OptionObject{

        public double s {get; set;}
        public double r {get; set;}
        public double v {get; set;}
        public double t {get; set;}
        public double strike {get; set;}  
        public bool call {get; set;}  
        public double payout {get; set;}
        public double barrier_level {get; set;}
        public int steps {get; set;}
        public int simulations {get; set;}
        public bool parallel_variate {get; set;}
        public string option_type {get; set;}
        public string antithetic {get; set;}
        public string control_variate {get; set;}
        public string control_variate_antithetic {get; set;}
        public string barrier_type {get; set;}
    }

    public class Result {
        public double option_price {get; set;}
        public double standard_error {get; set;}
        public double delta {get; set;}
        public double gamma {get; set;}
        public double vega  {get; set;}
        public double theta  {get; set;}
        public double rho  {get; set;}
    }

    public static class Result_API_Calc {
        
        public static Result results_calc(OptionObject ob) {

            double s = ob.s;
            double r = ob.r;
            double v = ob.v;
            double t = ob.t;
            double strike = ob.strike;
            bool call = ob.call; 
            double payout = ob.payout;
            double barrier_level = ob.barrier_level;
            int steps = ob.steps;
            int simulations = ob.simulations;
            bool parallel_variate = ob.parallel_variate;
            string option_type = ob.option_type;
            string antithetic = ob.antithetic;
            string control_variate = ob.control_variate;
            string control_variate_antithetic = ob.control_variate_antithetic;
            string barrier_type = ob.barrier_type;


            String exotic_user_input_european = "1";
            String exotic_user_input_asian = "2";
            String exotic_user_input_digital = "3";
            String exotic_user_input_barrier = "4";
            String exotic_user_input_lookback = "5";
            String exotic_user_input_range = "6";
            bool exotic_european = String.Equals(option_type, exotic_user_input_european);
            bool exotic_asian = String.Equals(option_type, exotic_user_input_asian);
            bool exotic_digital = String.Equals(option_type, exotic_user_input_digital);
            bool exotic_barrier = String.Equals(option_type, exotic_user_input_barrier);
            bool exotic_lookback = String.Equals(option_type, exotic_user_input_lookback);
            bool exotic_range = String.Equals(option_type, exotic_user_input_range);

            String yes = "yes";
            bool antithetic_bool = String.Equals(antithetic, yes);

            bool control_variate_bool = String.Equals(control_variate, yes);

            bool control_variate_antithetic_bool = String.Equals(control_variate_antithetic, yes);

            NormalRandomPaths nrp1 = new NormalRandomPaths();
            double[,] random_normal_paths = nrp1.fillRandomPaths(steps, simulations);

            SimulatedPaths sp1 = new SimulatedPaths();
            ExoticOptions eo1 = new ExoticOptions();
            //double[] end_row = new double[simulations];
            double final_value = 0;
            double[] control_variate_value_array = new double[simulations];
            //double control_variate_value = 0;
            Result result = new Result();
            //STANDARD ERROR
            StandardError std_err = new StandardError();

            if(exotic_european == true) {
                var simulated_paths = sp1.SimulatedPathsCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                double[] end_row = sp1.end_values(simulated_paths.Item1);
                result.option_price  = sp1.finalMean(r,t,end_row);
                result.standard_error = std_err.standard_error(end_row);
                if(antithetic_bool) {
                    end_row = sp1.AntitheticFinalCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,end_row);
                }
                else if(control_variate_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_based_call_old_way(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }
                else if(control_variate_antithetic_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_antithetic(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }
            }

            else if(exotic_asian == true) {
                var simulated_paths = sp1.SimulatedPathsCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                double[] end_row = sp1.end_values(simulated_paths.Item1);
                result.option_price  = eo1.Asian(s, r, v, t, steps, simulations, call, strike,random_normal_paths, parallel_variate);
                result.standard_error = std_err.standard_error(end_row);
                if(antithetic_bool) {
                    Console.WriteLine("Antithetic");
                    end_row = sp1.AntitheticFinalCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,end_row);
                }
                else if(control_variate_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_based_call_old_way(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }

                else if(control_variate_antithetic_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_antithetic(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }
            }

            else if(exotic_digital == true) {
                var simulated_paths = sp1.SimulatedPathsCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                double[] end_row = sp1.end_values(simulated_paths.Item1);
                result.option_price  = eo1.Digital(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate, payout);
                result.standard_error = std_err.standard_error(end_row);
                if(antithetic_bool) {
                    Console.WriteLine("Antithetic");
                    end_row = sp1.AntitheticFinalCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,end_row);
                }
                else if(control_variate_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_based_call_old_way(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }

                else if(control_variate_antithetic_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_antithetic(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }
                    
            }
            else if(exotic_barrier == true) {
                var simulated_paths = sp1.SimulatedPathsCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                double[] end_row = sp1.end_values(simulated_paths.Item1);
                result.option_price  = eo1.Barrier(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate, barrier_level, barrier_type);
                result.standard_error = std_err.standard_error(end_row);
                if(antithetic_bool) {
                    Console.WriteLine("Antithetic");
                    end_row = sp1.AntitheticFinalCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,end_row);
                }
                else if(control_variate_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_based_call_old_way(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }

                else if(control_variate_antithetic_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_antithetic(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }
                
            }
            else if(exotic_lookback == true) {
                var simulated_paths = sp1.SimulatedPathsCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                double[] end_row = sp1.end_values(simulated_paths.Item1);
                result.option_price  = eo1.Lookback(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                result.standard_error = std_err.standard_error(end_row);
                if(antithetic_bool) {
                    Console.WriteLine("Antithetic");
                    end_row = sp1.AntitheticFinalCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,end_row);
                }
                else if(control_variate_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_based_call_old_way(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }

                else if(control_variate_antithetic_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_antithetic(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }
                
            }
            else if(exotic_range == true) {
                var simulated_paths = sp1.SimulatedPathsCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                double[] end_row = sp1.end_values(simulated_paths.Item1);
                result.option_price  = eo1.Range(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                result.standard_error = std_err.standard_error(end_row);
                if(antithetic_bool) {
                    Console.WriteLine("Antithetic");
                    end_row = sp1.AntitheticFinalCalculation(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,end_row);
                }
                else if(control_variate_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_based_call_old_way(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }

                else if(control_variate_antithetic_bool) {
                    ControlVariate stv = new ControlVariate();
                    control_variate_value_array = stv.delta_antithetic(s, r, v, t, steps, simulations, call, strike, random_normal_paths, parallel_variate);
                    result.option_price = sp1.finalMean(r,t,control_variate_value_array);
                }
            }

        
        //result.option_price = exotic_option_price;
        //result.standard_error = standard_error;
        
            // THIS SECTION CALLS THE GREEK CLASS FOR EITHER THE ANTITHETIC OR NON ANTITHETIC
            //DELTA
            Greeks greek_methods = new Greeks();
            result.delta  = greek_methods.delta(s, r, v, t, steps, simulations, call, strike, random_normal_paths, antithetic_bool, control_variate_bool, control_variate_antithetic_bool, parallel_variate);

            //GAMMA
            result.gamma = greek_methods.gamma(s, r, v, t, steps, simulations, call, strike, random_normal_paths, final_value, antithetic_bool, control_variate_bool, control_variate_antithetic_bool, parallel_variate);

            //VEGA
            result.vega = greek_methods.vega(s, r, v, t, steps, simulations, call, strike, random_normal_paths, antithetic_bool, control_variate_bool, control_variate_antithetic_bool, parallel_variate);

            //THETA
            result.theta  = greek_methods.theta(s, r, v,  t, steps, simulations, call, strike, random_normal_paths, final_value, antithetic_bool, control_variate_bool, control_variate_antithetic_bool, parallel_variate);

            //RHO
            result.rho = greek_methods.rho(s, r, v, t, steps, simulations, call, strike, random_normal_paths, antithetic_bool, control_variate_bool, control_variate_antithetic_bool, parallel_variate);

            return result;
        }

    }

    [ApiController]
    [Route("[controller]")]
    public class MonteCarlo : ControllerBase 
    {
        [HttpPost]
        public Result Post([FromBody] OptionObject opob)
        {
             return Result_API_Calc.results_calc(opob);
        }


    }


    // SIMULATED PATHS - CALCULATE OPTION PRICES BASED ON CALL OR PUT AND GET THE FINAL OPTION PRICE OF ALL THE PATHS
    public class SimulatedPaths{

        //TAKE NORMAL RANDOM PATHS AND GET THE CALCUALTION. STORE THE LAST STEP OF EACH SIMULATION AND RETURN AN ARRAY OF ALL THE VALUES
        public Tuple<double[,], double[,]> SimulatedPathsCalculation(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool parallel){
            
            if(parallel) {
                return SimulatedPathsCalculationParallel(s, r, v, t, steps, simulation, call, strike, random_normal_paths);
            }

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
                  //double value = stock_values[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
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

    
            return new Tuple<double[,], double[,]>(SimulatedPaths, stock_values);
            
            
        }

        public Tuple<double[,], double[,]> SimulatedPathsCalculationParallel(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths){
                    
                    int num_cores = 0;
                    num_cores = Environment.ProcessorCount;

                    var result_collection = new List<Tuple<double[,], double[,]>>();

                    var random_collection = new List<double[,]>();

                    int slice = (int)Math.Floor((double)simulation/num_cores);

                    for(int i = 0; i < num_cores; i++) {
                        double[,] sliced_array = new double[slice, steps];
                        int a = i*slice;
                        int b = (i+1)*slice;
                        int start = 0;
                        for(int j = a; j < b; j++) {
                            for (int k = 0; k < steps; k++) {
                                sliced_array[start, k] = random_normal_paths[j, k];
                            }
                            start++;
                        }
                        random_collection.Add(sliced_array);

                    }
            
                    ParallelLoopResult parallel_paths = Parallel.For(0, num_cores, i => {
                        result_collection.Add(SimulatedPathsCalculation(s, r, v, t, steps, slice, call, strike, random_collection[i], false));
                    });

                   // List<double[,]> sim_paths_final_1 = new List<double[,]>();
                    //double[,] sim_paths_final_2 = new double[simulations_double, steps_double];
                   double[,] sim_paths_final = new double[simulation, steps];
                    //double[,] temp_1 = new double[slice, steps_double];
                    double[,] stocks_paths_final = new double[simulation, steps];
                    //double[,] temp_2 = new double[slice, steps_double];
                    //result_collection[1].Item1;
            
                    for(int i = 0; i < result_collection.Count; i++) {
                        //sim_paths_final_1.Add(result_collection[i].Item1);
                        int a = i*slice;
                        int b = (i+1)*slice;
                        int start_in = 0;
                        for(int j = a; j < b; j++) {
                            for (int k = 0; k < steps; k++) {
                                sim_paths_final[j, k] = result_collection[i].Item1[start_in, k]; 
                                stocks_paths_final[j, k] = result_collection[i].Item2[start_in, k]; 
                            }
                            start_in++;
                        }
                    }


                    return new Tuple<double[,], double[,]>(sim_paths_final, stocks_paths_final);
            
        }

        public double[] end_values(double[,] simulated_paths) {

            double[] end_values = new double[simulated_paths.GetLength(0)];
            for(int i = 0; i < simulated_paths.GetLength(0); i++){
                end_values[i] = simulated_paths[i, (simulated_paths.GetLength(1)-1)];
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
        public double[] AntitheticFinalCalculation(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool parallel) {
            double[,] antithetic_random_normal = new double[random_normal_paths.GetLength(0), random_normal_paths.GetLength(1)];

            // get the random normal values - multiply with -1
            for(int i = 0; i < random_normal_paths.GetLength(0); i++){
                for(int j = 0; j < random_normal_paths.GetLength(1); j++){
                    antithetic_random_normal[i,j] = -1*random_normal_paths[i,j];
                }
            }

            var e_paths = new Tuple<double[,], double[,]>(antithetic_random_normal, antithetic_random_normal);
            var e_hat_paths = new Tuple<double[,], double[,]>(antithetic_random_normal, antithetic_random_normal);


            // get the option prices for both random normal values
            if(parallel){
                e_paths = SimulatedPathsCalculationParallel(s,r,v,t,steps,simulation,call,strike,random_normal_paths);
                e_hat_paths = SimulatedPathsCalculationParallel(s,r,v,t,steps,simulation,call,strike,antithetic_random_normal);
            }
            
            e_paths = SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,random_normal_paths, parallel);
            e_hat_paths = SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,antithetic_random_normal, parallel);
            
            

            double[] e = end_values(e_paths.Item1);
            double[] e_hat = end_values(e_hat_paths.Item1);

            double[] simulated_antithethic_paths = new double[e.Length];
            
            // average of both
            for(int i = 0; i < e.Length; i++) {
                simulated_antithethic_paths[i] = (e[i] + e_hat[i])/2;
            }

            return simulated_antithethic_paths;
        }

    }

    public class ExoticOptions {

        public double Asian(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool parallel) {
            SimulatedPaths sp1 = new SimulatedPaths();
            double[,] simulated_paths = new double[simulation, steps];
            var paths = sp1.SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,random_normal_paths,parallel);
            Console.WriteLine("debug debug", paths.Item1);
            simulated_paths = paths.Item2;

            Console.WriteLine("Simualted paths: ",simulated_paths[1, 1]);

            double[] end_values = new double[simulated_paths.GetLength(0)];
            double[] end_values_payoff = new double[simulated_paths.GetLength(0)];

            double final_value = 0;

            double row_total = 0;
            double average = 0;
            double subtraction = 0;

            for(int i = 0; i < simulation; i++){
                for(int j = 0; j < steps; j++){
                    row_total = row_total + simulated_paths[i,j];
                    
                }
                //Console.WriteLine("Row Total: "+row_total);
                average = row_total/steps;
                //Console.WriteLine("Average Total: "+ average);
                end_values[i] = average;
                row_total = 0;
                average = 0;
            }

            for(int i = 0; i < simulation; i++) {
                if(call == true){
                    subtraction = end_values[i] - strike;
                }
                else{
                    subtraction =  strike - end_values[i];
                }
                end_values_payoff[i] = subtraction;
                //Console.WriteLine("End values payoff: "+ end_values_payoff[i]);
            }

            for(int i = 0; i < simulation; i++) {
                if(end_values_payoff[i] < 0){
                    end_values_payoff[i] = 0;
                }
                //Console.WriteLine("End values payoff: "+ end_values_payoff[i]);
            }


            final_value = sp1.finalMean(r, t, end_values_payoff);

            return final_value;

        }

        public double Digital(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool parallel, double payout) {
            SimulatedPaths sp1 = new SimulatedPaths();
            double[,] simulated_paths = new double[simulation, steps];
            var paths = sp1.SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,random_normal_paths,parallel);
            simulated_paths = paths.Item2;
            double final_value = 0;
            double[] end_vals_digi = new double[simulation];
            double[] end_vals_digi_final = new double[simulation];
            end_vals_digi = sp1.end_values(simulated_paths);
            
            for(int i = 0; i < simulation; i++) {
                if(call == true) {
                    if(end_vals_digi[i] > strike) {
                        end_vals_digi_final[i] = payout;
                    }
                    else {
                        end_vals_digi_final[i] = 0;
                    }
                        
                }
                else {
                    if(end_vals_digi[i] < strike) {
                        end_vals_digi_final[i] = payout;
                    }
                    else {
                        end_vals_digi_final[i] = 0;
                    }   
                }
            }
            return sp1.finalMean(r, t, end_vals_digi_final);
        }

        public double Barrier(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool parallel, double barrier_level, string barrier_type) {
            SimulatedPaths sp1 = new SimulatedPaths();
            double[,] simulated_paths = new double[simulation, steps];
            var paths = sp1.SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,random_normal_paths,parallel);
            simulated_paths = paths.Item2;
            double[] end_vals_barrier = new double[simulation];
            end_vals_barrier = sp1.end_values(simulated_paths);
            double[] end_vals_barrier_logic = new double[simulation];
            double[] end_vals_payoff = new double[simulation];

            double max_num = Double.MinValue;
            double min_num = Double.MinValue;

            if(barrier_type == "up_out") {
                Console.WriteLine("up_out");
                for(int i = 0; i < simulation; i++){
                    for(int j = 0; j < steps; j++){
                        if(max_num < simulated_paths[i,j]) {
                            max_num = simulated_paths[i,j];
                        }
                    }
                    //Console.WriteLine("max_num" + max_num);
                    if(max_num > barrier_level) {
                        end_vals_barrier_logic[i] = 0;
                    }
                    else{
                        end_vals_barrier_logic[i] = end_vals_barrier[i];
                    }
                   // Console.WriteLine("end_vals_barrier_logic" + end_vals_barrier_logic[i]);
                    max_num = Double.MinValue;    
              }

            }
            else if(barrier_type == "down_out") {
                Console.WriteLine("down_out");
                for(int i = 0; i < simulation; i++){
                    for(int j = 0; j < steps; j++){
                        if(min_num > simulated_paths[i,j]) {
                            min_num = simulated_paths[i,j];
                        }
                    }
                    if(min_num < barrier_level) {
                        end_vals_barrier_logic[i] = end_vals_barrier[i];
                    }
                    else{
                        end_vals_barrier_logic[i] = 0;
                    }
                    min_num = Double.MinValue;    
              }
            }

            else if(barrier_type == "up_in"){
                Console.WriteLine("up_in");
                for(int i = 0; i < simulation; i++){
                    for(int j = 0; j < steps; j++){
                        if(max_num < simulated_paths[i,j]) {
                            max_num = simulated_paths[i,j];
                        }
                    }
                    if(max_num > barrier_level) {
                        end_vals_barrier_logic[i] = end_vals_barrier[i];
                    }
                    else{
                        end_vals_barrier_logic[i] = 0;
                    } 
                    max_num = Double.MinValue;   
              }

            }
            else if(barrier_type == "down_in") {
                Console.WriteLine("down_in");
                for(int i = 0; i < simulation; i++){
                    for(int j = 0; j < steps; j++){
                        if(min_num > simulated_paths[i,j]) {
                            min_num = simulated_paths[i,j];
                        }
                    }
                    if(min_num < barrier_level) {
                        end_vals_barrier_logic[i] = end_vals_barrier[i];
                    }
                    else{
                        end_vals_barrier_logic[i] = 0;
                    } 
                    min_num = Double.MaxValue;
              }

            }
            
            double subtraction = 0;
            double path_val = 0;

            for(int i = 0; i < simulation; i++) {
                if(end_vals_barrier_logic[i] == 0) {
                    end_vals_payoff[i] = 0;                    
                }
                else{
                    if(call == true){
                        subtraction = end_vals_barrier_logic[i] - strike;
                        path_val = Math.Max(subtraction, 0);
                    }
                    //puts
                    else{
                        subtraction =  strike - end_vals_barrier_logic[i];
                        path_val = Math.Max(subtraction, 0);
                    }
                    end_vals_payoff[i] = path_val;
                }
            }

            double final_value = 0;
            final_value = sp1.finalMean(r, t, end_vals_payoff);

            return final_value;

        }
    

        public double Lookback(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool parallel) {
            SimulatedPaths sp1 = new SimulatedPaths();
            double[,] simulated_paths = new double[simulation, steps];
            var paths = sp1.SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,random_normal_paths,parallel);
            simulated_paths = paths.Item2;

            //max for calls
            double[] max_values = new double[simulation];
            double[] min_values = new double[simulation];

            double max_num = Double.MinValue;
            double min_num = Double.MaxValue;

            for(int i = 0; i < simulation; i++){
                for(int j = 0; j < steps; j++){
                    if(max_num < simulated_paths[i,j]) {
                        max_num = simulated_paths[i,j];
                    }
                    else if(min_num > simulated_paths[i,j]) {
                        min_num = simulated_paths[i,j];
                    }
                }
                max_values[i] = max_num;
                min_values[i] = min_num;
                max_num = Double.MinValue;
                min_num = Double.MaxValue;
            }

            //Console.WriteLine("lookvak" );

            double[] values_payoff = new double[simulation];
            
            for(int i = 0; i < simulation; i++) {
                //Console.WriteLine("lookvak" + values_payoff[i]);
                if(call == true) {
                    values_payoff[i] = max_values[i] - strike;
                }
                else {
                    values_payoff[i] = strike - min_values[i];
                }
                
            }

            for(int i = 0; i < simulation; i++) {
                if(values_payoff[i] < 0){
                    values_payoff[i] = 0;
                }
                //Console.WriteLine("End values payoff: "+ values_payoff[i]);
            }

            double final_value = 0;
            final_value = sp1.finalMean(r, t, values_payoff);
            return final_value;
        }

         public double Range(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool parallel) {
            SimulatedPaths sp1 = new SimulatedPaths();
            double[,] simulated_paths = new double[simulation, steps];
            var paths = sp1.SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,random_normal_paths,parallel);
            simulated_paths = paths.Item2;

            //max for calls
            double[] max_values = new double[simulation];
            double[] min_values = new double[simulation];

            double max_num = Double.MinValue;
            double min_num = Double.MaxValue;

            for(int i = 0; i < simulation; i++){
                for(int j = 0; j < steps; j++){
                    if(max_num < simulated_paths[i,j]) {
                        max_num = simulated_paths[i,j];
                    }
                    else if(min_num > simulated_paths[i,j]) {
                        min_num = simulated_paths[i,j];
                    }
                }
                max_values[i] = max_num;
                min_values[i] = min_num;
                max_num = Double.MinValue;
                min_num = Double.MaxValue;
            }

            double[] values_payoff = new double[simulation];
            
            for(int i = 0; i < simulation; i++) {
                values_payoff[i] = max_values[i] - min_values[i];
            }

            double final_value = 0;
            final_value = sp1.finalMean(r, t, values_payoff);
            return final_value;
        }

    }


    // CLASS FOR ALL THE GREEKS - DELTA, GAMMA, THETA, VEGA, RHO
    public class Greeks {
        
        // DELTA
        public double delta(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool antithetic, bool control_variate, bool control_variate_antithetic, bool parallel){
            
            // DELTA S CONSIDERATION
            double s_plus = s + 0.001;
            double s_minus = s - 0.001;
            double delta = 0;

            if(antithetic) {
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.AntitheticFinalCalculation(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = path1.AntitheticFinalCalculation(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                
                //FINAL FORMULA
                delta = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else if(control_variate) {
                ControlVariate ctr = new ControlVariate();
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = ctr.delta_based_call_old_way(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_based_call_old_way(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                
                //FINAL FORMULA
                delta = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else if(control_variate_antithetic) {
                ControlVariate ctr = new ControlVariate();
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = ctr.delta_antithetic(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_antithetic(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                
                //FINAL FORMULA
                delta = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else{
                 //GET SIMULATED PATHS WITH S_PLUS AND S_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                var paths_plus = path1.SimulatedPathsCalculation(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double[] paths_single = path1.end_values(paths_plus.Item1);
                double final_mean_plus = path1.finalMean(r, t, paths_single);

                var paths_minus = path1.SimulatedPathsCalculation(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double[] paths_single_minus = path1.end_values(paths_minus.Item1);
                double final_mean_minus = path1.finalMean(r, t, paths_single_minus);
                
                //FINAL FORMULA
                delta = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            return delta;
        }

        //GAMMA
        public double gamma(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, double final_value, bool antithetic, bool control_variate, bool control_variate_antithetic, bool parallel){
            
            // GAMMA S CONSIDERATION
            double s_plus = s + 0.001*s;
            double s_minus = s - 0.001*s;
            double gamma = 0;

            if(antithetic) {
                // GET SIMULATED PATHS WITH S_PLUS AND S_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.AntitheticFinalCalculation(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = path1.AntitheticFinalCalculation(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                gamma = (final_mean_plus + final_mean_minus - 2*final_value)/(Math.Pow((0.001*s),2));

            }
            else if(control_variate) {
                // GET SIMULATED PATHS WITH S_PLUS AND S_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_based_call_old_way(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_based_call_old_way(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                gamma = (final_mean_plus + final_mean_minus - 2*final_value)/(Math.Pow((0.001*s),2));

            }

            else if(control_variate_antithetic) {
                // GET SIMULATED PATHS WITH S_PLUS AND S_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_antithetic(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_antithetic(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);
                gamma = (final_mean_plus + final_mean_minus - 2*final_value)/(Math.Pow((0.001*s),2));

            }

            else{
                // GET SIMULATED PATHS WITH S_PLUS AND S_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                var paths_plus = path1.SimulatedPathsCalculation(s_plus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double[] paths_plus_single = path1.end_values(paths_plus.Item1);
                double final_mean_plus = path1.finalMean(r, t, paths_plus_single);

                var paths_minus = path1.SimulatedPathsCalculation(s_minus, r, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double[] paths_minus_single = path1.end_values(paths_minus.Item1);
                double final_mean_minus = path1.finalMean(r, t, paths_minus_single);

                gamma = (final_mean_plus + final_mean_minus - 2*final_value)/(Math.Pow((0.001*s),2));

            }
            return gamma;
        }

        //VEGA
        public double vega(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool antithetic, bool control_variate, bool control_variate_antithetic, bool parallel){
            
            // VEGA SIGMA CONSIDERATION
            double v_plus = v + 0.001;
            double v_minus = v - 0.001;
            double vega = 0;

            if(antithetic){
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.AntitheticFinalCalculation(s, r, v_plus, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = path1.AntitheticFinalCalculation(s, r, v_minus, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);

                //FINAL FORMULA
                vega = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else if(control_variate){
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_based_call_old_way(s, r, v_plus, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_based_call_old_way(s, r, v_minus, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);

                //FINAL FORMULA
                vega = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else if(control_variate_antithetic){
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_antithetic(s, r, v_plus, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                double[] paths_minus = ctr.delta_antithetic(s, r, v_minus, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);

                //FINAL FORMULA
                vega = (final_mean_plus - final_mean_minus)/(2*0.001);

            }

            else {
                // GET SIMULATED PATHS WITH V_PLUS AND V_MINUS
                SimulatedPaths path1 = new SimulatedPaths();
                var paths_plus_single = path1.SimulatedPathsCalculation(s, r, v_plus, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double[] paths_plus = path1.end_values(paths_plus_single.Item1);
                double final_mean_plus = path1.finalMean(r, t, paths_plus);

                var paths_minus_single = path1.SimulatedPathsCalculation(s, r, v_minus, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double[] paths_minus = path1.end_values(paths_minus_single.Item1);
                double final_mean_minus = path1.finalMean(r, t, paths_minus);

                //FINAL FORMULA
                vega = (final_mean_plus - final_mean_minus)/(2*0.001);
            }
            return vega;
        }

        // THETA
        public double theta(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, double final_value, bool antithetic, bool control_variate, bool control_variate_antithetic, bool parallel){
            
            // DELTA TIME CONSIDERATION
            double t_plus = t + 0.001*t;
            double theta = 0;

            if(antithetic){

                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.AntitheticFinalCalculation(s, r, v, t_plus, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t_plus, paths_plus);

                //final formula
                theta = (final_mean_plus - final_value)/(0.001*t);

            }

            else if(control_variate){

                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_based_call_old_way(s, r, v, t_plus, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t_plus, paths_plus);

                //final formula
                theta = (final_mean_plus - final_value)/(0.001*t);

            }

             else if(control_variate_antithetic){

                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_antithetic(s, r, v, t_plus, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r, t_plus, paths_plus);

                //final formula
                theta = (final_mean_plus - final_value)/(0.001*t);

            }

            else{
                SimulatedPaths path1 = new SimulatedPaths();
                var paths_plus_single = path1.SimulatedPathsCalculation(s, r, v, t_plus, steps, simulation, call, strike, random_normal_paths, parallel);
                double[] paths_plus = path1.end_values(paths_plus_single.Item1);
                double final_mean_plus = path1.finalMean(r, t_plus, paths_plus);

                //final formula
                theta = (final_mean_plus - final_value)/(0.001*t);

            }

            //get simulated paths with t_plus
            

            return theta;
        }

        //RHO
        public double rho(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool antithetic, bool control_variate, bool control_variate_antithetic, bool parallel){
            
            //delta r
            double r_plus = r + 0.1;
            double r_minus = r - 0.1;
            double rho = 0;

            if(antithetic) {
                SimulatedPaths path1 = new SimulatedPaths();
                double[] paths_plus = path1.AntitheticFinalCalculation(s, r_plus, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r_plus, t, paths_plus);

                double[] paths_minus = path1.AntitheticFinalCalculation(s, r_minus, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r_minus, t, paths_minus);

                // rho formula
                rho = (final_mean_plus - final_mean_minus)/(2*0.1);

            }

            else if(control_variate) {
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_based_call_old_way(s, r_plus, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r_plus, t, paths_plus);

                double[] paths_minus = ctr.delta_based_call_old_way(s, r_minus, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r_minus, t, paths_minus);

                // rho formula
                rho = (final_mean_plus - final_mean_minus)/(2*0.1);

            }

            else if(control_variate_antithetic) {
                SimulatedPaths path1 = new SimulatedPaths();
                ControlVariate ctr = new ControlVariate();
                double[] paths_plus = ctr.delta_antithetic(s, r_plus, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_plus = path1.finalMean(r_plus, t, paths_plus);

                double[] paths_minus = ctr.delta_antithetic(s, r_minus, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double final_mean_minus = path1.finalMean(r_minus, t, paths_minus);

                // rho formula
                rho = (final_mean_plus - final_mean_minus)/(2*0.1);

            }

            else{
                SimulatedPaths path1 = new SimulatedPaths();
                var paths_plus_single = path1.SimulatedPathsCalculation(s, r_plus, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double[] paths_plus = path1.end_values(paths_plus_single.Item1);
                double final_mean_plus = path1.finalMean(r_plus, t, paths_plus);

                var paths_minus_single = path1.SimulatedPathsCalculation(s, r_minus, v, t, steps, simulation, call, strike, random_normal_paths, parallel);
                double[] paths_minus = path1.end_values(paths_minus_single.Item1);
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
         public double[] delta_based_call_old_way(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool parallel)
        {
            //variables
            double[,] stock_values = new double[simulation, steps];
            double[,] SimulatedPaths = new double[simulation, steps];
            double subtraction = 0;
            double path_val = 0;
            double betal = -1;
            double delta = 0;

            BlackScholes bs = new BlackScholes();
            SimulatedPaths sp = new SimulatedPaths();
            //NormalRandom nrm = new NormalRandom();

            if(parallel) {
                var output = sp.SimulatedPathsCalculationParallel(s,r,v,t,steps,simulation,call,strike,random_normal_paths);
                stock_values = output.Item2;
                
            }
            else{
                var output = sp.SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,random_normal_paths, parallel);
                stock_values = output.Item2;
            }
            
            

            // double for loop to go over each step in every simulation and apply the payoff function
            // A double array is filled in this for loop
            for(int i = 0; i < simulation; i++){
                double cv = 0;
                for(int j = 1; j < steps; j++){
                    //calls
                    if(call == true){
                        delta = bs.callDelta(stock_values[i, j-1],r,v,t,strike);
                        //Console.WriteLine("Debug debug"+stock_values[i, j-1]);
                        double steps_calc = t/steps;
                        //double value = stock_values[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                        cv = cv + (delta * (stock_values[i, j] - (stock_values[i, j-1] * Math.Exp(r*steps_calc))));
                        subtraction = stock_values[i, j] - strike;
                        path_val = Math.Max(subtraction, 0) + (betal*cv);
                    }
                    //puts
                    else{
                        delta = bs.putDelta(stock_values[i, j-1],r,v,t,strike);
                        double steps_calc = t/steps;
                        //double value = stock_values[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                        cv = cv + delta * (stock_values[i, j] - (stock_values[i, j-1] * Math.Exp(r*steps_calc)));
                        //stock_values[i, j] = value;
                        subtraction =  strike - stock_values[i, j];
                        path_val = Math.Max(subtraction, 0) + (betal*cv);
                    }
                    SimulatedPaths[i,j] = path_val;
                }
            }
            
            // this for loop retrieves the last value of each step and returns the single dimension array
            double[] end_values = new double[SimulatedPaths.GetLength(0)];
            for(int i = 0; i < SimulatedPaths.GetLength(0); i++){
                end_values[i] = SimulatedPaths[i, (SimulatedPaths.GetLength(1)-1)];
                //Console.WriteLine("Control Variate Project 2 "+ end_values[i]);
            }

            return end_values;
        }

         public double[] delta_antithetic(double s, double r, double v, double t, int steps, int simulation, bool call, double strike, double[,] random_normal_paths, bool parallel)
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

            SimulatedPaths sp = new SimulatedPaths();
            
            // get the random normal values - multiply with -1
            for(int i = 0; i < random_normal_paths.GetLength(0); i++){
                for(int j = 0; j < random_normal_paths.GetLength(1); j++){
                    antithetic_random_normal[i,j] = -1*random_normal_paths[i,j];
                }
            }

            if(parallel) {
                var output_1 = sp.SimulatedPathsCalculationParallel(s,r,v,t,steps,simulation,call,strike,random_normal_paths);
                var output_2 = sp.SimulatedPathsCalculationParallel(s,r,v,t,steps,simulation,call,strike,antithetic_random_normal);
                stock_values_1 = output_1.Item2;
                stock_values_2 = output_2.Item2;
            }
            else{
                var output_1 = sp.SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,random_normal_paths, parallel);
                var output_2 = sp.SimulatedPathsCalculation(s,r,v,t,steps,simulation,call,strike,antithetic_random_normal, parallel);
                stock_values_1 = output_1.Item2;
                stock_values_2 = output_2.Item2;
            }
            

            // double for loop to go over each step in every simulation and apply the payoff function
            // A double array is filled in this for loop
            for(int i = 0; i < simulation; i++){
                double cv1 = 0;
                double cv2 = 0;
                for(int j = 1; j < steps; j++){
                    //calls
                    if(call == true){
                        delta1 = bs.callDelta(stock_values_1[i, j-1],r,v,t,strike);
                        delta2 = bs.callDelta(stock_values_2[i, j-1],r,v,t,strike);
                        double steps_calc = t/steps;
                        //double value1 = stock_values_1[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                        //double value2 = stock_values_2[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((antithetic_random_normal[i,j] * v * (Math.Sqrt(steps_calc)))));
                        cv1 = cv1 + delta1 * (stock_values_1[i, j] - (stock_values_1[i, j-1] * Math.Exp(r*steps_calc)));
                        cv2 = cv2 + delta2 * (stock_values_2[i, j] - (stock_values_2[i, j-1] * Math.Exp(r*steps_calc)));

                        //stock_values_1[i, j] = value1;
                        //stock_values_2[i, j] = value2;
                        subtraction1 = stock_values_1[i, j] - strike;
                        subtraction2 = stock_values_2[i, j] - strike;
                        path_val = 0.5*(Math.Max(subtraction1, 0) + (betal*cv1) + Math.Max(subtraction2, 0) + (betal*cv2));
                    }
                    //puts
                    else{
                        delta1 = bs.callDelta(stock_values_1[i, j-1],r,v,t,strike);
                        delta2 = bs.callDelta(stock_values_2[i, j-1],r,v,t,strike);
                        double steps_calc = t/steps;
                        //double value1 = stock_values_1[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((random_normal_paths[i,j] * v * (Math.Sqrt(steps_calc)))));
                        //double value2 = stock_values_2[i, j-1] * Math.Exp((r - ((Math.Pow(v, 2))*0.5))*(steps_calc) + ((antithetic_random_normal[i,j] * v * (Math.Sqrt(steps_calc)))));
                        cv1 = cv1 + delta1 * (stock_values_1[i, j] - (stock_values_1[i, j-1] * Math.Exp(r*steps_calc)));
                        cv2 = cv2 + delta2 * (stock_values_2[i, j] - (stock_values_2[i, j-1] * Math.Exp(r*steps_calc)));

                        //stock_values_1[i, j] = value1;
                        //stock_values_2[i, j] = value2;
                        subtraction1 =  strike - stock_values_1[i, j];
                        subtraction2 =  strike - stock_values_2[i, j];
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



[Table("Exchanges")]
        public class Exchange
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public string ShortCode {get; set;}
    }
    [Table("Market")]
    public class Market
    {
        public int Id {get;set;}
        public string Name {get;set;}
    }
    [Table("Units")]
    public class Units
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public double Quantity {get;set;}
    }
    
    [Table("Underlying")]
    public class Underlying
    {
        public Exchange Exchange {get; set;}
        public int ExchangeId {get; set;}

        public int Id {get; set;}
        public string CorpName {get; set;}
        public string Ticker {get; set;}
    }
    [Table("Options")]
    public class Option
    {
        public int Id {get; set;}
        public Underlying Underlying {get; set;}
        public DateTimeOffset ExpirationDate {get; set;}
    }
    [Table("European")]
    public class European : Option
    {
        public double strike {get; set;}
        public bool IsCall {get; set;}
    }
    [Table("Asian")]
    public class Asian : Option
    {
        public double strike {get; set;}
        public bool IsCall {get; set;}
    }
    [Table("Digital")]
    public class Digital : Option
    {
        public double strike {get; set;}
        public bool IsCall {get; set;}
        public double payout {get; set;}
    }
    [Table("Lookback")]
    public class Lookback : Option
    {
        public double strike {get; set;}
        public bool IsCall {get; set;}
    }
    [Table("Barrier")]
    public class Barrier : Option
    {
        public double strike {get; set;}
        public bool IsCall {get; set;}
        public int BarrierTypeID {get; set;}
        public double BarrierLevel {get; set;}
    }
    [Table("Range")]
    public class Range : Option
    {
       
    }
    [Table("HistoricalPrice")]
    public class HistoricalPrice
    {
        public int Id {get;set;}
        public Underlying Underlying {get;set;}
        public int UnderlyingId {get; set;}
        public double Price {get;set;}
        public DateTimeOffset Date {get;set;}
    }
    [Table("Trade")]
    public class Trade
    {
        public int Id {get; set;}
        public double Quantity {get; set;}
        public Underlying Instrument {get; set;}

        public double Price {get; set;}
        public DateTimeOffset Date {get; set;}
    }
    [Table("TradeEvaluation")]
    public class TradeEvaluation
    {
        public int Id {get; set;}
        public double MarketValue {get; set;}
        // add greeks 
    }
    public class FinancialContext : DbContext
    {
        public DbSet<Units> Units {get; set;}
        public DbSet<Exchange> Exchanges {get; set;}
        //public DbSet<Instrument> Instruments {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost;Database=montecarlo;Username=postgres;Password=root") ;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Seed Exchange data
        modelBuilder.Entity<Exchange>().HasData(
            new Exchange { Id = 1, Name = "Chicago Mercantile Exchange", ShortCode = "CME" }
        );

        // Seed Unit data
        modelBuilder.Entity<Units>().HasData(
            new Units { Id = 1, Name = "Bushels" },
            new Units { Id = 2, Name = "Gallons" }
        );

        // Seed RateCurve data
        // modelBuilder.Entity<RateCurve>().HasData(
        //     new RateCurve { Id = 1, Name = "US Treasury Curve" }
        // );
    }
    }

    


    }

}

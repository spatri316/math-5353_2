let exchangeList = [];
let marketList = [];
let unitList = [];
let curvesList = [];
let underlyingList = [];
let instrumentList = [];
let tradeList = [];


document.getElementById("exchange_btn").addEventListener("click", function(){
  var exchangeTableContainer = document.getElementById('tableContainerExchange');
  var unitsTableContainer = document.getElementById('tableContainerUnits');
  var curvesTableContainer = document.getElementById('tableContainerCurves');
  var marketTableContainer = document.getElementById('tableContainerMarkets');
  var priceTableContainer = document.getElementById('tableContainerPrices');
  var ratesTableContainer = document.getElementById('tableContainerRates');
  var underlyingTableContainer = document.getElementById('tableContainerUnderlyings');
  var derivativesTableContainer = document.getElementById('tableContainerDerivates');
  var tradesTableContainer = document.getElementById('tableContainerTrades');

  // Show the Exchange table and hide the Units table
  exchangeTableContainer.style.display = 'block';
  unitsTableContainer.style.display = 'none';
  curvesTableContainer.style.display = 'none';
  marketTableContainer.style.display = 'none';
  priceTableContainer.style.display = 'none';
  ratesTableContainer.style.display = 'none';
  underlyingTableContainer.style.display = 'none';
  derivativesTableContainer.style.display = 'none';
  tradesTableContainer.style.display = 'none';

  });

document.getElementById("units_btn").addEventListener("click", function(){
  var exchangeTableContainer = document.getElementById('tableContainerExchange');
  var unitsTableContainer = document.getElementById('tableContainerUnits');
  var curvesTableContainer = document.getElementById('tableContainerCurves');
  var marketTableContainer = document.getElementById('tableContainerMarkets');
  var priceTableContainer = document.getElementById('tableContainerPrices');
  var ratesTableContainer = document.getElementById('tableContainerRates');
  var underlyingTableContainer = document.getElementById('tableContainerUnderlyings');
  var derivativesTableContainer = document.getElementById('tableContainerDerivates');
  var tradesTableContainer = document.getElementById('tableContainerTrades');

  // Show the Units table and hide the Exchange table
  exchangeTableContainer.style.display = 'none';
  unitsTableContainer.style.display = 'block';
  curvesTableContainer.style.display = 'none';
  marketTableContainer.style.display = 'none';
  priceTableContainer.style.display = 'none';
  ratesTableContainer.style.display = 'none';
  underlyingTableContainer.style.display = 'none';
  derivativesTableContainer.style.display = 'none';
  tradesTableContainer.style.display = 'none';

  
  });

document.getElementById("curves_btn").addEventListener("click", function(){
  var exchangeTableContainer = document.getElementById('tableContainerExchange');
  var unitsTableContainer = document.getElementById('tableContainerUnits');
  var curvesTableContainer = document.getElementById('tableContainerCurves');
  var marketTableContainer = document.getElementById('tableContainerMarkets');
  var priceTableContainer = document.getElementById('tableContainerPrices');
  var ratesTableContainer = document.getElementById('tableContainerRates');
  var underlyingTableContainer = document.getElementById('tableContainerUnderlyings');
  var derivativesTableContainer = document.getElementById('tableContainerDerivates');
  var tradesTableContainer = document.getElementById('tableContainerTrades');

  // Show the Units table and hide the Exchange table
  exchangeTableContainer.style.display = 'none';
  unitsTableContainer.style.display = 'none';
  curvesTableContainer.style.display = 'block';
  marketTableContainer.style.display = 'none';
  priceTableContainer.style.display = 'none';
  ratesTableContainer.style.display = 'none';
  underlyingTableContainer.style.display = 'none';
  derivativesTableContainer.style.display = 'none';
  tradesTableContainer.style.display = 'none';


  });

  document.getElementById("markets_btn").addEventListener("click", function(){
    var exchangeTableContainer = document.getElementById('tableContainerExchange');
    var unitsTableContainer = document.getElementById('tableContainerUnits');
    var curvesTableContainer = document.getElementById('tableContainerCurves');
    var marketTableContainer = document.getElementById('tableContainerMarkets');
    var priceTableContainer = document.getElementById('tableContainerPrices');
    var ratesTableContainer = document.getElementById('tableContainerRates');
    var underlyingTableContainer = document.getElementById('tableContainerUnderlyings');
    var derivativesTableContainer = document.getElementById('tableContainerDerivates');
    var tradesTableContainer = document.getElementById('tableContainerTrades');
  
    // Show the Units table and hide the Exchange table
    exchangeTableContainer.style.display = 'none';
    unitsTableContainer.style.display = 'none';
    curvesTableContainer.style.display = 'none';
    marketTableContainer.style.display = 'block';
    priceTableContainer.style.display = 'none';
    ratesTableContainer.style.display = 'none';
    underlyingTableContainer.style.display = 'none';
    derivativesTableContainer.style.display = 'none';
    tradesTableContainer.style.display = 'none';

  
    });

    document.getElementById("prices_btn").addEventListener("click", function(){
      var exchangeTableContainer = document.getElementById('tableContainerExchange');
      var unitsTableContainer = document.getElementById('tableContainerUnits');
      var curvesTableContainer = document.getElementById('tableContainerCurves');
      var marketTableContainer = document.getElementById('tableContainerMarkets');
      var priceTableContainer = document.getElementById('tableContainerPrices');
      var ratesTableContainer = document.getElementById('tableContainerRates');
      var underlyingTableContainer = document.getElementById('tableContainerUnderlyings');
      var derivativesTableContainer = document.getElementById('tableContainerDerivates');
      var tradesTableContainer = document.getElementById('tableContainerTrades');
    
      // Show the Units table and hide the Exchange table
      exchangeTableContainer.style.display = 'none';
      unitsTableContainer.style.display = 'none';
      curvesTableContainer.style.display = 'none';
      marketTableContainer.style.display = 'none';
      priceTableContainer.style.display = 'block';
      ratesTableContainer.style.display = 'none';
      underlyingTableContainer.style.display = 'none';
      derivativesTableContainer.style.display = 'none';
      tradesTableContainer.style.display = 'none';

    
      });

document.getElementById("rates_btn").addEventListener("click", function(){
  var exchangeTableContainer = document.getElementById('tableContainerExchange');
  var unitsTableContainer = document.getElementById('tableContainerUnits');
  var curvesTableContainer = document.getElementById('tableContainerCurves');
  var marketTableContainer = document.getElementById('tableContainerMarkets');
  var priceTableContainer = document.getElementById('tableContainerPrices');
  var ratesTableContainer = document.getElementById('tableContainerRates');
  var underlyingTableContainer = document.getElementById('tableContainerUnderlyings');
  var derivativesTableContainer = document.getElementById('tableContainerDerivates');
  var tradesTableContainer = document.getElementById('tableContainerTrades');

  // Show the Units table and hide the Exchange table
  exchangeTableContainer.style.display = 'none';
  unitsTableContainer.style.display = 'none';
  curvesTableContainer.style.display = 'none';
  marketTableContainer.style.display = 'none';
  priceTableContainer.style.display = 'none';
  ratesTableContainer.style.display = 'block';
  underlyingTableContainer.style.display = 'none';
  derivativesTableContainer.style.display = 'none';
  tradesTableContainer.style.display = 'none';


  });

  document.getElementById("underlying_btn").addEventListener("click", function(){
    var exchangeTableContainer = document.getElementById('tableContainerExchange');
    var unitsTableContainer = document.getElementById('tableContainerUnits');
    var curvesTableContainer = document.getElementById('tableContainerCurves');
    var marketTableContainer = document.getElementById('tableContainerMarkets');
    var priceTableContainer = document.getElementById('tableContainerPrices');
    var ratesTableContainer = document.getElementById('tableContainerRates');
    var underlyingTableContainer = document.getElementById('tableContainerUnderlyings');
    var derivativesTableContainer = document.getElementById('tableContainerDerivates');
    var tradesTableContainer = document.getElementById('tableContainerTrades');
  
    // Show the Units table and hide the Exchange table
    exchangeTableContainer.style.display = 'none';
    unitsTableContainer.style.display = 'none';
    curvesTableContainer.style.display = 'none';
    marketTableContainer.style.display = 'none';
    priceTableContainer.style.display = 'none';
    ratesTableContainer.style.display = 'none';
    underlyingTableContainer.style.display = 'block';
    derivativesTableContainer.style.display = 'none';
    tradesTableContainer.style.display = 'none';

  
    });

    document.getElementById("derivatives_btn").addEventListener("click", function(){
      var exchangeTableContainer = document.getElementById('tableContainerExchange');
      var unitsTableContainer = document.getElementById('tableContainerUnits');
      var curvesTableContainer = document.getElementById('tableContainerCurves');
      var marketTableContainer = document.getElementById('tableContainerMarkets');
      var priceTableContainer = document.getElementById('tableContainerPrices');
      var ratesTableContainer = document.getElementById('tableContainerRates');
      var underlyingTableContainer = document.getElementById('tableContainerUnderlyings');
      var derivativesTableContainer = document.getElementById('tableContainerDerivates');
      var tradesTableContainer = document.getElementById('tableContainerTrades');
    
      // Show the Units table and hide the Exchange table
      exchangeTableContainer.style.display = 'none';
      unitsTableContainer.style.display = 'none';
      curvesTableContainer.style.display = 'none';
      marketTableContainer.style.display = 'none';
      priceTableContainer.style.display = 'none';
      ratesTableContainer.style.display = 'none';
      underlyingTableContainer.style.display = 'none';
      derivativesTableContainer.style.display = 'block';
      tradesTableContainer.style.display = 'none';
    
      });

      document.getElementById("trades_btn").addEventListener("click", function(){
        var exchangeTableContainer = document.getElementById('tableContainerExchange');
        var unitsTableContainer = document.getElementById('tableContainerUnits');
        var curvesTableContainer = document.getElementById('tableContainerCurves');
        var marketTableContainer = document.getElementById('tableContainerMarkets');
        var priceTableContainer = document.getElementById('tableContainerPrices');
        var ratesTableContainer = document.getElementById('tableContainerRates');
        var underlyingTableContainer = document.getElementById('tableContainerUnderlyings');
        var derivativesTableContainer = document.getElementById('tableContainerDerivates');
        var tradesTableContainer = document.getElementById('tableContainerTrades');
      
        // Show the Units table and hide the Exchange table
        exchangeTableContainer.style.display = 'none';
        unitsTableContainer.style.display = 'none';
        curvesTableContainer.style.display = 'none';
        marketTableContainer.style.display = 'none';
        priceTableContainer.style.display = 'none';
        ratesTableContainer.style.display = 'none';
        underlyingTableContainer.style.display = 'none';
        derivativesTableContainer.style.display = 'none';
        tradesTableContainer.style.display = 'block';
      
        });
  
getExchanges();
getUnits();
getCurves();
getMarket();
getPrices();
getRates();
getUnderlying();
getDerivatives();
getTrades();


function getExchanges() {
 
  let tablebody = document.getElementById("tableBodyExchanges");
  let rowcount = tablebody.rows.length;
  for(let j = 0; j < rowcount; j++) {
    tablebody.deleteRow(-1);
  }
  let request = new XMLHttpRequest();
  request.open("GET", "http://localhost:5283/Exchange/Exchanges");
  console.log("AM I HERE");
  request.onload = () => {
    if(request.status === 200) {
      let values = JSON.parse(request.response);
      for(let i = 0; i < values.length; i++) {
        var row = tablebody.insertRow(tablebody.rows.length);
        var idCol = row.insertCell();
        var nameCol = row.insertCell();
        var shortcodeCol = row.insertCell();
        idCol.innerHTML  = values[i].id;
        nameCol.innerHTML = values[i].name;
        shortcodeCol.innerHTML = values[i].shortCode;

      }
      this.exchangeList = values;
     // updateExchangeReferences();
    }
    else {
      console.log("LOST");
      alert("Error getting Exchange Data");
    }
    
  }
  request.send();
}

function postNewExchanges() {

  let request = new XMLHttpRequest();

  request.open("POST", "http://localhost:5283/Exchange/Exchanges", true);
  request.setRequestHeader("Content-Type", "application/json");

  let txtName = document.getElementById("txtExchangeName").value;
  let txtSymbol = document.getElementById("txtExchangeShortcode").value;

  const body = JSON.stringify({
    "Name": txtName,
    "ShortCode": txtSymbol
  });

  request.onload = () => {
    if (request.readyState == 4 && request.status == 201) {
      console.log(JSON.parse(request.responseText));
    } else {
      console.log(`Error: ${request.status}`);
    }
  };
  request.send(body);

}


function getUnits() {
 
  let tablebody = document.getElementById("tableBodyUnits");
  let rowcount = tablebody.rows.length;
  for(let j = 0; j < rowcount; j++) {
    tablebody.deleteRow(-1);
  }
  let request = new XMLHttpRequest();
  request.open("GET", "http://localhost:5283/Units/Units");
  console.log("AM I HERE");
  request.onload = () => {
    if(request.status === 200) {
      let values = JSON.parse(request.response);
      for(let i = 0; i < values.length; i++) {
        var row = tablebody.insertRow(tablebody.rows.length);
        var idCol = row.insertCell();
        var nameCol = row.insertCell();
        idCol.innerHTML  = values[i].id;
        nameCol.innerHTML = values[i].name;
      }
      this.unitsList = values;
     // updateExchangeReferences();
    }
    else {
      console.log("LOST");
      alert("Error getting Exchange Data");
    }
    
  }
  request.send();
}

function postNewUnits() {

  let request = new XMLHttpRequest();

  request.open("POST", "http://localhost:5283/Units/Units", true);
  request.setRequestHeader("Content-Type", "application/json");

  let txtName = document.getElementById("txtUnitName").value;

  const body = JSON.stringify({
    "Name": txtName,
  });

  request.onload = () => {
    if (request.readyState == 4 && request.status == 201) {
      console.log(JSON.parse(request.responseText));
    } else {
      console.log(`Error: ${request.status}`);
    }
  };
  request.send(body);

}

function getCurves() {
 
  let tablebody = document.getElementById("tableBodyCurves");
  let rowcount = tablebody.rows.length;
  for(let j = 0; j < rowcount; j++) {
    tablebody.deleteRow(-1);
  }
  let request = new XMLHttpRequest();
  request.open("GET", "http://localhost:5283/Curves/Curves");
  console.log("AM I HERE");
  request.onload = () => {
    if(request.status === 200) {
      let values = JSON.parse(request.response);
      for(let i = 0; i < values.length; i++) {
        var row = tablebody.insertRow(tablebody.rows.length);
        var idCol = row.insertCell();
        var nameCol = row.insertCell();
        idCol.innerHTML  = values[i].id;
        nameCol.innerHTML = values[i].name;
      }
      this.unitsList = values;
     // updateExchangeReferences();
    }
    else {
      console.log("LOST");
      alert("Error getting Exchange Data");
    }
    
  }
  request.send();
}

function postNewCurves() {

  let request = new XMLHttpRequest();

  request.open("POST", "http://localhost:5283/Curves/Curves", true);
  request.setRequestHeader("Content-Type", "application/json");

  let txtName = document.getElementById("txtCurveName").value;

  const body = JSON.stringify({
    "Name": txtName,
  });

  request.onload = () => {
    if (request.readyState == 4 && request.status == 201) {
      console.log(JSON.parse(request.responseText));
    } else {
      console.log(`Error: ${request.status}`);
    }
  };
  request.send(body);

}


function getMarket() {
 
  let tablebody = document.getElementById("tableBodyMarket");
  let rowcount = tablebody.rows.length;
  for(let j = 0; j < rowcount; j++) {
    tablebody.deleteRow(-1);
  }
  let request = new XMLHttpRequest();
  request.open("GET", "http://localhost:5283/Market/Markets");
  request.onload = () => {
    if(request.status === 200) {
      let values = JSON.parse(request.response);
      for(let i = 0; i < values.length; i++) {
        console.log("AM I HERE in markets", values[i].id);
        var row = tablebody.insertRow(tablebody.rows.length);
        var idCol = row.insertCell();
        var nameCol = row.insertCell();
        var symbolCol = row.insertCell();
        var sizeCol = row.insertCell();
        var unitCol = row.insertCell();
        var multiplierCol = row.insertCell();
        var exchangeCol = row.insertCell();
        var curveCol = row.insertCell();
        idCol.innerHTML  = values[i].id;
        nameCol.innerHTML = values[i].name;
        symbolCol.innerHTML = values[i].symbol;
        sizeCol.innerHTML  = values[i].size;
        unitCol.innerHTML = values[i].unit;
        multiplierCol.innerHTML  = values[i].multiplier;
        exchangeCol.innerHTML = values[i].exchange;
        curveCol.innerHTML = values[i].curve;
      }
      this.marketList = values;
    }
    else {
      console.log("LOST");
      alert("Error getting Exchange Data");
    }
    
  }
  request.send();
}

function selectUnitsMarket() {
  const xhr = new XMLHttpRequest();

    // Configure it with the GET request to your server endpoint
    xhr.open("GET", "http://localhost:5283/Market/UniqueUnits", true);


    // Define the callback function to handle the response
    xhr.onload = function() {
      if (xhr.status >= 200 && xhr.status < 300) {

        console.log(xhr.responseText);
          const data = JSON.parse(xhr.responseText);
          let selectDropdown = document.getElementById("txtMarketUnits");

          selectDropdown.innerHTML = "";

          data.forEach(unit => {
              const option = document.createElement("option");
              option.value = unit;
              option.text = unit;
              selectDropdown.add(option);
          });
      } else {
          console.error("Error fetching data:", xhr.statusText);
      }
  };

    // Handle network errors
    xhr.onerror = function() {
      console.error("Network error");
  };

  xhr.send();
}


function selectExchangeMarket() {
  const xhr = new XMLHttpRequest();

    // Configure it with the GET request to your server endpoint
    xhr.open("GET", "http://localhost:5283/Market/UniqueExchanges", true);



    // Define the callback function to handle the response
    xhr.onload = function() {
      if (xhr.status >= 200 && xhr.status < 300) {
          const data = JSON.parse(xhr.responseText);

          console.log(xhr.responseText);
          let selectDropdown = document.getElementById("txtMarketExchange");

          data.forEach(exchange => {
              const option = document.createElement("option");
              option.value = exchange;
              option.text = exchange;
              selectDropdown.add(option);
          });
      } else {
          console.error("Error fetching data:", xhr.statusText);
      }
  };

    // Handle network errors
    xhr.onerror = function() {
      console.error("Network error");
  };

  xhr.send();
}


function selectCurveMarket() {
  const xhr = new XMLHttpRequest();

    // Configure it with the GET request to your server endpoint
    xhr.open("GET", "http://localhost:5283/Market/UniqueRateCurves", true);

    // Define the callback function to handle the response
    xhr.onload = function() {
      if (xhr.status >= 200 && xhr.status < 300) {
          const data = JSON.parse(xhr.responseText);
          let selectDropdown = document.getElementById("txtMarketRate");

          console.log(xhr.responseText);

          selectDropdown.innerHTML = "";

          data.forEach(unit => {
              const option = document.createElement("option");
              option.value = unit;
              option.text = unit;
              selectDropdown.add(option);
          });
      } else {
          console.error("Error fetching data:", xhr.statusText);
      }
  };

    // Handle network errors
    xhr.onerror = function() {
      console.error("Network error");
  };

  xhr.send();
}

function postNewMarket() {

  var selectedUnit;
  var selectedExchange;
  var selectedCurve;

  let request_units = new XMLHttpRequest();
  request_units.open("GET", "http://localhost:5283/Units/Units", false);
  request_units.onload = () => {
    if(request_units.status === 200) {
      unitList = JSON.parse(request_units.responseText);
      selectedUnit = unitList.find(unit => unit.name === document.getElementById("txtMarketUnits").value);
      console.log(selectedUnit);
    }
  }
  request_units.send()

  let request_exchange = new XMLHttpRequest();
  request_exchange.open("GET", "http://localhost:5283/Exchange/Exchanges", false);
  request_exchange.onload = () => {
    if(request_exchange.status === 200) {
      exchangeList = JSON.parse(request_exchange.responseText);
      selectedExchange = exchangeList.find(exchange => exchange.shortCode === document.getElementById("txtMarketExchange").value);
      console.log(selectedExchange);
    }
  }

  request_exchange.send()

  let request_curve = new XMLHttpRequest();
  request_curve.open("GET", "http://localhost:5283/Curves/Curves", false);
  request_curve.onload = () => {
    if(request_curve.status === 200) {
      curveList = JSON.parse(request_curve.responseText);
      selectedCurve = curveList.find(curve => curve.name === document.getElementById("txtMarketRate").value);
      console.log(selectedCurve);
    }
  } 
  request_curve.send();

  let request = new XMLHttpRequest();
  request.open("POST", "http://localhost:5283/Market/Markets", true);
  request.setRequestHeader("Content-Type", "application/json");

  let txtName = document.getElementById("txtMarketName").value;
  let txtSymbol = document.getElementById("txtMarketSymbol").value;
  let txtSize = document.getElementById("txtMarketSize").value;
  let txtMultiplier = document.getElementById("txtMarketMultiplier").value;

  console.log(selectedUnit.name);

  const body = JSON.stringify({
    "Name": txtName,
    "Symbol": txtSymbol,
    "Size": txtSize,
    "UnitID": selectedUnit.id,
    "Unit": selectedUnit.name,
    "Multiplier": txtMultiplier,
    "ExchangeId": selectedExchange.id,
    "Exchange": selectedExchange.shortCode,
    "RateCurveId": selectedCurve.id,
    "Curve": selectedCurve.name,
  });

  
  request.onload = () => {
    if (request.readyState == 4 && request.status == 201) {
      console.log(JSON.parse(request.responseText));
    } else {
      console.log(`Error: ${request.status}`);
    }
  };
  request.send(body);

}

function getPrices() {
 
  let tablebody = document.getElementById("tableBodyPrices");
  let rowcount = tablebody.rows.length;
  for(let j = 0; j < rowcount; j++) {
    tablebody.deleteRow(-1);
  }
  let request = new XMLHttpRequest();
  request.open("GET", "http://localhost:5283/Price/Prices");
  request.onload = () => {
    if(request.status === 200) {
      let values = JSON.parse(request.response);
      console.log(values)
      for(let i = 0; i < values.length; i++) {
        console.log("AM I HERE in prices", values[i].id);
        var row = tablebody.insertRow(tablebody.rows.length);
        var idCol = row.insertCell();
        var dateCol = row.insertCell();
        var instCol = row.insertCell();
        var priceCol = row.insertCell();
        idCol.innerHTML  = values[i].id;
        dateCol.innerHTML = values[i].date;
        instCol.innerHTML = values[i].instSymbolName;
        priceCol.innerHTML  = values[i].priceNum;
      }
      this.marketList = values;
    }
    else {
      console.log("LOST");
      alert("Error getting Exchange Data");
    }
    
  }
  request.send();
}

function selectInstrumentPrice() {
  const xhr = new XMLHttpRequest();

    // Configure it with the GET request to your server endpoint
    xhr.open("GET", "http://localhost:5283/Price/UniqueInstruments", true);

    // Define the callback function to handle the response
    xhr.onload = function() {
      if (xhr.status >= 200 && xhr.status < 300) {
          const data = JSON.parse(xhr.responseText);
          let selectDropdown = document.getElementById("txtPriceInstrument");

          console.log(xhr.responseText);

          selectDropdown.innerHTML = "";

          data.forEach(instrument => {
              const option = document.createElement("option");
              option.value = instrument;
              option.text = instrument;
              selectDropdown.add(option);
          });
      } else {
          console.error("Error fetching data:", xhr.statusText);
      }
  };

    // Handle network errors
    xhr.onerror = function() {
      console.error("Network error");
  };

  xhr.send();
}


function postNewPrice() {

  var selectedInstrument;

  let request_instrument = new XMLHttpRequest();
  request_instrument.open("GET", "http://localhost:5283/Instrument/Instruments", false);
  request_instrument.onload = () => {
    if(request_instrument.status === 200) {
      instrumentList = JSON.parse(request_instrument.responseText);
      selectedInstrument = instrumentList.find(instrument => instrument.symbol === document.getElementById("txtPriceInstrument").value);
      console.log(selectedInstrument);
    }
  }
  request_instrument.send();

  let request = new XMLHttpRequest();
  request.open("POST", "http://localhost:5283/Price/Prices", true);
  request.setRequestHeader("Content-Type", "application/json");

  let txtPrice = document.getElementById("txtPricePrice").value;
  let txtDate= document.getElementById("txtPriceDate").value;
  //let utcDate = DateTime.SpecifyKind(txtDate.Date, DateTimeKind.utcDate);

  const body = JSON.stringify({
    "InstSymbolId": selectedInstrument.id,
    "InstSymbolName": selectedInstrument.symbol,
    "PriceNum": txtPrice,
    "Date": txtDate
  });

  request.onload = () => {
    if (request.readyState == 4 && request.status == 201) {
      console.log(JSON.parse(request.responseText));
    } else {
      console.log(`Error: ${request.status}`);
    }
  };
  request.send(body);

}

function getRates() {
 
  let tablebody = document.getElementById("tableBodyRates");
  let rowcount = tablebody.rows.length;
  for(let j = 0; j < rowcount; j++) {
    tablebody.deleteRow(-1);
  }
  let request = new XMLHttpRequest();
  request.open("GET", "http://localhost:5283/Rate/Rates");
  request.onload = () => {
    if(request.status === 200) {
      let values = JSON.parse(request.response);
      console.log(values);
      for(let i = 0; i < values.length; i++) {
        var row = tablebody.insertRow(tablebody.rows.length);
        var idCol = row.insertCell();
        var tenorCol = row.insertCell();
        var rateCol = row.insertCell();
        var curveCol = row.insertCell();
        idCol.innerHTML  = values[i].id;
        tenorCol.innerHTML = values[i].tenor;
        rateCol.innerHTML = values[i].rate;
        curveCol.innerHTML  = values[i].curveName;
      }
    }
    else {
      console.log("LOST");
      alert("Error getting Exchange Data");
    }
    
  }
  request.send();
}

function selectCurveRates() {
  const xhr = new XMLHttpRequest();

    // Configure it with the GET request to your server endpoint
    xhr.open("GET", "http://localhost:5283/Rate/UniqueCurves", true);

    // Define the callback function to handle the response
    xhr.onload = function() {
      if (xhr.status >= 200 && xhr.status < 300) {
          const data = JSON.parse(xhr.responseText);
          let selectDropdown = document.getElementById("txtRateCurve");

          console.log(xhr.responseText);

          selectDropdown.innerHTML = "";

          data.forEach(instrument => {
              const option = document.createElement("option");
              option.value = instrument;
              option.text = instrument;
              selectDropdown.add(option);
          });
      } else {
          console.error("Error fetching data:", xhr.statusText);
      }
  };

    // Handle network errors
    xhr.onerror = function() {
      console.error("Network error");
  };

  xhr.send();
}


function postNewRate() {

  var selectedCurve;

  let request_curve = new XMLHttpRequest();
  request_curve.open("GET", "http://localhost:5283/Curves/Curves", false);
  request_curve.onload = () => {
    if(request_curve.status === 200) {
      curveList = JSON.parse(request_curve.responseText);
      selectedCurve = curveList.find(curve => curve.name === document.getElementById("txtRateCurve").value);
    }
  }
  request_curve.send();

  console.log(selectedCurve);

  let request = new XMLHttpRequest();
  request.open("POST", "http://localhost:5283/Rate/Rates", true);
  request.setRequestHeader("Content-Type", "application/json");

  let txtTenor  = document.getElementById("txtRateTenor").value;
  let txtRate = document.getElementById("txtRateRate").value;
  //let utcDate = DateTime.SpecifyKind(txtDate.Date, DateTimeKind.utcDate);

  const body = JSON.stringify({
    "Tenor": txtTenor,
    "rate": txtRate,
    "RateCurveId": selectedCurve.id,
    "CurveName": selectedCurve.name
  });

  request.onload = () => {
    if (request.readyState == 4 && request.status == 201) {
      console.log(JSON.parse(request.responseText));
    } else {
      console.log(`Error: ${request.status}`);
    }
  };
  request.send(body);

}


function getUnderlying() {
 
  let tablebody = document.getElementById("tableBodyUnderlyings");
  let rowcount = tablebody.rows.length;
  for(let j = 0; j < rowcount; j++) {
    tablebody.deleteRow(-1);
  }
  let request = new XMLHttpRequest();
  request.open("GET", "http://localhost:5283/Underlying/Underlyings");
  request.onload = () => {
    if(request.status === 200) {
      let values = JSON.parse(request.response);
      console.log(values);
      for(let i = 0; i < values.length; i++) {
        var row = tablebody.insertRow(tablebody.rows.length);
        var idCol = row.insertCell();
        var symbolCol = row.insertCell();
        var marketCol = row.insertCell();
        var monthCol = row.insertCell();
        var yearCol = row.insertCell();
        var expirationCol = row.insertCell();
        idCol.innerHTML  = values[i].id;
        symbolCol.innerHTML  = values[i].symbol;
        marketCol.innerHTML  = values[i].market;
        monthCol.innerHTML = values[i].month;
        yearCol.innerHTML  = values[i].year;
        expirationCol.innerHTML  = values[i].expiration;
      }
      this.marketList = values;
    }
    else {
      console.log("LOST");
      alert("Error getting Exchange Data");
    }
    
  }
  request.send();
}

function selectMarketUnderlying() {
  const xhr = new XMLHttpRequest();

    // Configure it with the GET request to your server endpoint
    xhr.open("GET", "http://localhost:5283/Underlying/UniqueMarkets", true);

    // Define the callback function to handle the response
    xhr.onload = function() {
      if (xhr.status >= 200 && xhr.status < 300) {
          const data = JSON.parse(xhr.responseText);
          let selectDropdown = document.getElementById("txtUnderlyingMarket");

          console.log(xhr.responseText);

          selectDropdown.innerHTML = "";

          data.forEach(instrument => {
              const option = document.createElement("option");
              option.value = instrument;
              option.text = instrument;
              selectDropdown.add(option);
          });
      } else {
          console.error("Error fetching data:", xhr.statusText);
      }
  };

    // Handle network errors
    xhr.onerror = function() {
      console.error("Network error");
  };

  xhr.send();
}


function postNewUnderlying() {

  var selectedMarket;

  let request_market = new XMLHttpRequest();
  request_market.open("GET", "http://localhost:5283/Market/Markets", false);
  request_market.onload = () => {
    if(request_market.status === 200) {
      marketList = JSON.parse(request_market.responseText);
      selectedMarket = marketList.find(market => market.name === document.getElementById("txtUnderlyingMarket").value);
      console.log(selectedMarket);
    }
  }
  request_market.send();

  let request = new XMLHttpRequest();
  request.open("POST", "http://localhost:5283/Underlying/Underlyings", true);
  request.setRequestHeader("Content-Type", "application/json");

  let txtMonth = document.getElementById("txtUnderlyingMonth").value;
  let txtYear = document.getElementById("txtUnderlyingYear").value;
  let txtDate= document.getElementById("txtUnderlyingDate").value;
  let txtSymbol = document.getElementById("txtUnderlyingSymbol").value;
  //let utcDate = DateTime.SpecifyKind(txtDate.Date, DateTimeKind.utcDate);

  const body = JSON.stringify({
    "MarketId": selectedMarket.id,
    "Market": selectedMarket.name,
    "Year": txtYear,
    "Month": txtMonth,
    "Expiration": txtDate,
    "Symbol": txtSymbol

  });

  request.onload = () => {
    if (request.readyState == 4 && request.status == 201) {
      console.log(JSON.parse(request.responseText));
    } else {
      console.log(`Error: ${request.status}`);
    }
  };
  request.send(body);

}


function getDerivatives() {
 
  let tablebody = document.getElementById("tableBodyDerivatives");
  let rowcount = tablebody.rows.length;
  for(let j = 0; j < rowcount; j++) {
    tablebody.deleteRow(-1);
  }
  let request = new XMLHttpRequest();
  request.open("GET", "http://localhost:5283/Derivatives/Derivatives");
  request.onload = () => {
    if(request.status === 200) {
      let values = JSON.parse(request.response);
      console.log(values);
      for(let i = 0; i < values.length; i++) {
        var row = tablebody.insertRow(tablebody.rows.length);
        var idCol = row.insertCell();
        var symbolCol = row.insertCell();
        var marketCol = row.insertCell();
        var instTypeCol = row.insertCell();
        var monthCol = row.insertCell();
        var yearCol = row.insertCell();
        var underlyingCol = row.insertCell();
        var strikeCol = row.insertCell();
        var callPutCol = row.insertCell();
        var payoutCol = row.insertCell();
        var barrierTypeCol = row.insertCell();
        var barrierLevelCol = row.insertCell();
        var expirationCol = row.insertCell();
        idCol.innerHTML  = values[i].id;
        symbolCol.innerHTML  = values[i].symbol;
        marketCol.innerHTML  = values[i].market;
        monthCol.innerHTML = values[i].underlyingMonth;        ;
        yearCol.innerHTML  = values[i].underlyingYear;
        expirationCol.innerHTML  = values[i].expiration;
        instTypeCol.innerHTML = values[i].instType;
        underlyingCol.innerHTML = values[i].underlying;
        strikeCol.innerHTML = values[i].strike;
        callPutCol.innerHTML = values[i].call_Put;
        payoutCol.innerHTML = values[i].payout;
        barrierTypeCol.innerHTML = values[i].barrierType;
        barrierLevelCol.innerHTML = values[i].barrierLevel;
      }
    }
    else {
      console.log("LOST");
      alert("Error getting Exchange Data");
    }
    
  }
  request.send();
}

function selectMarketDerivative() {
  const xhr = new XMLHttpRequest();

    // Configure it with the GET request to your server endpoint
    xhr.open("GET", "http://localhost:5283/Derivatives/UniqueMarkets", true);

    // Define the callback function to handle the response
    xhr.onload = function() {
      if (xhr.status >= 200 && xhr.status < 300) {
          const data = JSON.parse(xhr.responseText);
          let selectDropdown = document.getElementById("txtDerivativeMarket");

          console.log(xhr.responseText);

          selectDropdown.innerHTML = "";

          data.forEach(instrument => {
              const option = document.createElement("option");
              option.value = instrument;
              option.text = instrument;
              selectDropdown.add(option);
          });
      } else {
          console.error("Error fetching data:", xhr.statusText);
      }
  };

    // Handle network errors
    xhr.onerror = function() {
      console.error("Network error");
  };

  xhr.send();
}


function selectUnderlyingDerivative() {
  const xhr = new XMLHttpRequest();

    // Configure it with the GET request to your server endpoint
    xhr.open("GET", "http://localhost:5283/Derivatives/UniqueUnderlyings", true);

    // Define the callback function to handle the response
    xhr.onload = function() {
      if (xhr.status >= 200 && xhr.status < 300) {
          const data = JSON.parse(xhr.responseText);
          let selectDropdown = document.getElementById("txtDerivativeUnderlying");

          console.log(xhr.responseText);

          selectDropdown.innerHTML = "";

          data.forEach(instrument => {
              const option = document.createElement("option");
              option.value = instrument;
              option.text = instrument;
              selectDropdown.add(option);
          });
      } else {
          console.error("Error fetching data:", xhr.statusText);
      }
  };

    // Handle network errors
    xhr.onerror = function() {
      console.error("Network error");
  };

  xhr.send();
}

function postNewDerivative() {

  var selectedMarket;
  var selectedUnderlying;

  let request_market = new XMLHttpRequest();
  request_market.open("GET", "http://localhost:5283/Market/Markets", false);
  request_market.onload = () => {
    if(request_market.status === 200) {
      marketList = JSON.parse(request_market.responseText);
      selectedMarket = marketList.find(market => market.name === document.getElementById("txtDerivativeMarket").value);
      console.log(selectedMarket);
    }
  }
  request_market.send();

  let request_underlying = new XMLHttpRequest();
  request_underlying.open("GET", "http://localhost:5283/Underlying/Underlyings", false);
  request_underlying.onload = () => {
    if(request_underlying.status === 200) {
      selectedUnderlying = JSON.parse(request_underlying.responseText);
      selectedUnderlying = selectedUnderlying.find(underlying => underlying.symbol === document.getElementById("txtDerivativeUnderlying").value);
      console.log(selectedUnderlying);
    }
  }
  request_underlying.send();

  let request = new XMLHttpRequest();
  request.open("POST", "http://localhost:5283/Derivatives/Derivatives", true);
  request.setRequestHeader("Content-Type", "application/json");

  let txtDate= document.getElementById("txtDerivativeDate").value;
  let txtSymbol = document.getElementById("txtDerivativeSymbol").value;
//  let txtMarket = document.getElementById("txtDerivativeMarket").value;
  let txtInstType = document.getElementById("txtDerivativeInstType").value;
  let txtStrike = document.getElementById("txtDerivativeStrike").value;
 // let txtUnderlyi = document.getElementById("txtDerivativeInstType").value;
  let txtCallPut = document.getElementById("txtDerivativeCallPut").value;
  let txtPayout = document.getElementById("txtDerivativePayout").value;
  let txtBarrierType = document.getElementById("txtDerivativeBarrierType").value;
  let txtBarrierLevel = document.getElementById("txtDerivativeBarrierLevel").value;

  const body = JSON.stringify({
    "marketId":selectedMarket.id,
    "market":selectedMarket.name,
    "instType":txtInstType,
    "underlyingMonth": selectedUnderlying.month,
    "underlyingYear":selectedUnderlying.year,
    "underlyingId":selectedUnderlying.id,
    "underlying":selectedUnderlying.symbol,
    "strike":txtStrike,
    "call_Put":txtCallPut,
    "payout":txtPayout,
    "barrierType":txtBarrierType,
    "barrierLevel":txtBarrierLevel,
    "expiration":txtDate,
    "symbol":txtSymbol
  });

  request.onload = () => {
    if (request.readyState == 4 && request.status == 201) {
      console.log(JSON.parse(request.responseText));
    } else {
      console.log(`Error: ${request.status}`);
    }
  };
  request.send(body);

}

function getTrades() {
 
  let tablebody = document.getElementById("tableBodyTrades");
  let rowcount = tablebody.rows.length;
  for(let j = 0; j < rowcount; j++) {
    tablebody.deleteRow(-1);
  }
  let request = new XMLHttpRequest();
  request.open("GET", "http://localhost:5283/Trade/Trades");
  request.onload = () => {
    if(request.status === 200) {
      let values = JSON.parse(request.response);
      console.log(values);
      for(let i = 0; i < values.length; i++) {
        var row = tablebody.insertRow(tablebody.rows.length);
        var idCol = row.insertCell();
        var quantityCol = row.insertCell();
        var symbolCol = row.insertCell();
        var priceCol = row.insertCell();
        var dateCol = row.insertCell();
        idCol.innerHTML  = values[i].id;
        quantityCol.innerHTML  = values[i].quantity;
        symbolCol.innerHTML  = values[i].symbolName;
        priceCol.innerHTML = values[i].price;        ;
        dateCol.innerHTML  = values[i].date;
      }
    }
    else {
      console.log("LOST");
      alert("Error getting Exchange Data");
    }
    
  }
  request.send();
}


function selectInstrumentTrades() {
  const xhr = new XMLHttpRequest();

    // Configure it with the GET request to your server endpoint
    xhr.open("GET", "http://localhost:5283/Trade/UniqueInstruments", true);

    // Define the callback function to handle the response
    xhr.onload = function() {
      if (xhr.status >= 200 && xhr.status < 300) {
          const data = JSON.parse(xhr.responseText);
          let selectDropdown = document.getElementById("txtTradeInstrument");

          console.log(xhr.responseText);

          selectDropdown.innerHTML = "";

          data.forEach(instrument => {
              const option = document.createElement("option");
              option.value = instrument;
              option.text = instrument;
              selectDropdown.add(option);
          });
      } else {
          console.error("Error fetching data:", xhr.statusText);
      }
  };

    // Handle network errors
    xhr.onerror = function() {
      console.error("Network error");
  };

  xhr.send();
}


function postNewTrade() {

  var selectedInstrument;

  let request_instrument = new XMLHttpRequest();
  request_instrument.open("GET", "http://localhost:5283/Instrument/Instruments", false);
  request_instrument.onload = () => {
    if(request_instrument.status === 200) {
      instrumentList = JSON.parse(request_instrument.responseText);
      selectedInstrument = instrumentList.find(instrument => instrument.symbol === document.getElementById("txtTradeInstrument").value);
      console.log(selectedInstrument);
    }
  }
  request_instrument.send();

  let request = new XMLHttpRequest();
  request.open("POST", "http://localhost:5283/Trade/Trades", true);
  request.setRequestHeader("Content-Type", "application/json");

  let txtQuantity = document.getElementById("txtTradeQuantity").value;
  let txtPrice = document.getElementById("txtTradePrice").value;
  //let utcDate = DateTime.SpecifyKind(txtDate.Date, DateTimeKind.utcDate);

  const body = JSON.stringify({
    "Quantity": txtQuantity,
    "SymbolId": selectedInstrument.id,
    "SymbolName": selectedInstrument.symbol,
    "Price": txtPrice,
    "Date": selectedInstrument.expirationDate
  });
  
  request.onload = () => {
    if (request.readyState == 4 && request.status == 201) {
      console.log(JSON.parse(request.responseText));
    } else {
      console.log(`Error: ${request.status}`);
    }
  };
  request.send(body);

}





document.getElementById("btnRefreshExchange").addEventListener("click", function() {getExchanges()});
document.getElementById("btnSaveExchange").addEventListener("click", function() {postNewExchanges()});

document.getElementById("btnRefreshUnits").addEventListener("click", function() {getUnits()});
document.getElementById("btnSaveUnit").addEventListener("click", function() {postNewUnits()});

document.getElementById("btnRefreshCurves").addEventListener("click", function() {getCurves()});
document.getElementById("btnSaveCurve").addEventListener("click", function() {postNewCurves()});

document.getElementById("btnRefreshMarket").addEventListener("click", function() {getMarket()});
document.getElementById("btnSaveMarket").addEventListener("click", function() {postNewMarket()});

document.getElementById("btnRefreshPrices").addEventListener("click", function() {getPrices()});
document.getElementById("btnSavePrice").addEventListener("click", function() {postNewPrice()});

document.getElementById("btnRefreshRates").addEventListener("click", function() {getRates()});
document.getElementById("btnSaveRate").addEventListener("click", function() {postNewRate()});

document.getElementById("btnRefreshUnderlying").addEventListener("click", function() {getUnderlying()});
document.getElementById("btnSaveUnderlying").addEventListener("click", function() {postNewUnderlying()});

document.getElementById("btnRefreshDerivatives").addEventListener("click", function() {getDerivatives()});
document.getElementById("btnSaveDerivative").addEventListener("click", function() {postNewDerivative()});

document.getElementById("btnRefreshTrades").addEventListener("click", function() {getTrades()});
document.getElementById("btnSaveTrades").addEventListener("click", function() {postNewTrade()});

document.getElementById("txtMarketUnits").addEventListener("click", function() {selectUnitsMarket()});
document.getElementById("txtMarketExchange").addEventListener("click", function() {selectExchangeMarket()});
document.getElementById("txtMarketRate").addEventListener("click", function() {selectCurveMarket()});

document.getElementById("txtPriceInstrument").addEventListener("click", function() {selectInstrumentPrice()});

document.getElementById("txtRateCurve").addEventListener("click", function() {selectCurveRates()});

document.getElementById("txtUnderlyingMarket").addEventListener("click", function() {selectMarketUnderlying()});

document.getElementById("txtDerivativeMarket").addEventListener("click", function() {selectMarketDerivative()});
document.getElementById("txtDerivativeUnderlying").addEventListener("click", function() {selectUnderlyingDerivative()});

document.getElementById("txtTradeInstrument").addEventListener("click", function() {selectInstrumentTrades()});
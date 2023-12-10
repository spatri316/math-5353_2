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

  // Show the Exchange table and hide the Units table
  exchangeTableContainer.style.display = 'block';
  unitsTableContainer.style.display = 'none';
  curvesTableContainer.style.display = 'none';
  marketTableContainer.style.display = 'none';

  });

document.getElementById("units_btn").addEventListener("click", function(){
  var exchangeTableContainer = document.getElementById('tableContainerExchange');
  var unitsTableContainer = document.getElementById('tableContainerUnits');
  var curvesTableContainer = document.getElementById('tableContainerCurves');
  var marketTableContainer = document.getElementById('tableContainerMarkets');

  // Show the Units table and hide the Exchange table
  exchangeTableContainer.style.display = 'none';
  unitsTableContainer.style.display = 'block';
  curvesTableContainer.style.display = 'none';
  marketTableContainer.style.display = 'none';

  
  });

document.getElementById("curves_btn").addEventListener("click", function(){
  var exchangeTableContainer = document.getElementById('tableContainerExchange');
  var unitsTableContainer = document.getElementById('tableContainerUnits');
  var curvesTableContainer = document.getElementById('tableContainerCurves');
  var marketTableContainer = document.getElementById('tableContainerMarkets');

  // Show the Units table and hide the Exchange table
  exchangeTableContainer.style.display = 'none';
  unitsTableContainer.style.display = 'none';
  curvesTableContainer.style.display = 'block';
  marketTableContainer.style.display = 'none';

  });

  document.getElementById("markets_btn").addEventListener("click", function(){
    var exchangeTableContainer = document.getElementById('tableContainerExchange');
    var unitsTableContainer = document.getElementById('tableContainerUnits');
    var curvesTableContainer = document.getElementById('tableContainerCurves');
    var marketTableContainer = document.getElementById('tableContainerMarkets');
  
    // Show the Units table and hide the Exchange table
    exchangeTableContainer.style.display = 'none';
    unitsTableContainer.style.display = 'none';
    curvesTableContainer.style.display = 'none';
    marketTableContainer.style.display = 'block';
  
    });
  
getExchanges();
getUnits();
getCurves();
getMarket();

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


document.getElementById("btnRefreshExchange").addEventListener("click", function() {getExchanges()});
document.getElementById("btnSaveExchange").addEventListener("click", function() {postNewExchanges()});

document.getElementById("btnRefreshUnits").addEventListener("click", function() {getUnits()});
document.getElementById("btnSaveUnit").addEventListener("click", function() {postNewUnits()});

document.getElementById("btnRefreshCurves").addEventListener("click", function() {getCurves()});
document.getElementById("btnSaveCurve").addEventListener("click", function() {postNewCurves()});

document.getElementById("btnRefreshMarket").addEventListener("click", function() {getMarket()});
document.getElementById("btnSaveMarket").addEventListener("click", function() {postNewMarket()});

document.getElementById("txtMarketUnits").addEventListener("click", function() {selectUnitsMarket()});
document.getElementById("txtMarketExchange").addEventListener("click", function() {selectExchangeMarket()});
document.getElementById("txtMarketRate").addEventListener("click", function() {selectCurveMarket()});



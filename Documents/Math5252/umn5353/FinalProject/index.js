document.getElementById("exchange_btn").addEventListener("click", function(){
  var exchangeTableContainer = document.getElementById('tableContainerExchange');
  var unitsTableContainer = document.getElementById('tableContainerUnits');
  var curvesTableContainer = document.getElementById('tableContainerCurves');

  // Show the Exchange table and hide the Units table
  exchangeTableContainer.style.display = 'block';
  unitsTableContainer.style.display = 'none';
  curvesTableContainer.style.display = 'none';
  });

document.getElementById("units_btn").addEventListener("click", function(){
  var exchangeTableContainer = document.getElementById('tableContainerExchange');
  var unitsTableContainer = document.getElementById('tableContainerUnits');
  var curvesTableContainer = document.getElementById('tableContainerCurves');

  // Show the Units table and hide the Exchange table
  exchangeTableContainer.style.display = 'none';
  unitsTableContainer.style.display = 'block';
  curvesTableContainer.style.display = 'none';
  
  });

document.getElementById("curves_btn").addEventListener("click", function(){
  var exchangeTableContainer = document.getElementById('tableContainerExchange');
  var unitsTableContainer = document.getElementById('tableContainerUnits');
  var curvesTableContainer = document.getElementById('tableContainerCurves');

  // Show the Units table and hide the Exchange table
  exchangeTableContainer.style.display = 'none';
  unitsTableContainer.style.display = 'none';
  curvesTableContainer.style.display = 'block';

  });
  
getExchanges();
getUnits();
getCurves();

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

document.getElementById("btnRefreshExchange").addEventListener("click", function() {getExchanges()});
document.getElementById("btnSaveExchange").addEventListener("click", function() {postNewExchanges()});


document.getElementById("btnRefreshUnits").addEventListener("click", function() {getUnits()});
document.getElementById("btnSaveUnit").addEventListener("click", function() {postNewUnits()});

document.getElementById("btnRefreshCurves").addEventListener("click", function() {getCurves()});
document.getElementById("btnSaveCurve").addEventListener("click", function() {postNewCurves()});


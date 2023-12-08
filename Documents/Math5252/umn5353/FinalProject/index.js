document.getElementById("exchange_btn").addEventListener("click", function(){
    var tableContainer = document.getElementById('tableContainer');

  // Toggle the display property to show/hide the table
    if (tableContainer.style.display === 'none' || tableContainer.style.display === '') {
        tableContainer.style.display = 'block';
    } else {
        tableContainer.style.display = 'none';
    }
  });
  
getExchanges();

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

  request.send(JSON.stringify({
    "Name": txtName,
    "ShortCode": txtSymbol
  }))

  // Optionally handle success here, e.g., show a success message
  console.log("Exchange added successfully");

}

document.getElementById("btnRefreshExchange").addEventListener("click", function() {getExchanges()});
document.getElementById("btnSaveExchange").addEventListener("click", function() {postNewExchanges()});


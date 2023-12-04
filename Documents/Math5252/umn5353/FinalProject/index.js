document.getElementById("exchange_btn").addEventListener("click", function(){
    var tableContainer = document.getElementById('tableContainer');

  // Toggle the display property to show/hide the table
    if (tableContainer.style.display === 'none' || tableContainer.style.display === '') {
        tableContainer.style.display = 'block';
    } else {
        tableContainer.style.display = 'none';
    }
  });
  

  
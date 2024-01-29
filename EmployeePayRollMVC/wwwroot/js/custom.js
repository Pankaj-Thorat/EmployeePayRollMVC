




function validateDate() {
    var appointmentDataInput = document.getElementById("startDate");
    var selectedDate = new Date(appointmentDataInput.value);

    var currentDate = new Date();

    currentDate.setHours(0, 0, 0, 0);

    if (selectedDate < currentDate) {
        alert('Please select future date!!');
        appointmentDataInput.value = '';
    }
}
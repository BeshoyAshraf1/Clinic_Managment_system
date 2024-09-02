const form = document.getElementById('appointmentForm');

form.addEventListener('input', () => {
    document.getElementById('infoSpecialty').textContent = document.getElementById('field').value || 'N/A';
    document.getElementById('infoDoctor').textContent = document.getElementById('doctor').value || 'N/A';
    document.getElementById('infoDate').textContent = document.getElementById('date').value || 'N/A';
    document.getElementById('infoTime').textContent = document.getElementById('time').value || 'N/A';
    document.getElementById('infoMessage').textContent = document.getElementById('message').value || 'N/A';
});




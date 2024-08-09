// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', () => {
    flatpickr("#dateInput", {
        altInput: true,
        altFormat: "F j, Y",
        dateFormat: "Y-m-d"
    });
});
document.getElementById('generatePasswordButton').addEventListener('click', () => {
    const password = generatePassword(10);
    document.getElementById('GeneratedPassword').value = password;
});

function generatePassword(length) {
    const lowercase = 'abcdefghijklmnopqrstuvwxyz';
    const uppercase = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    const numbers = '0123456789';
    const allCharacters = lowercase + uppercase + numbers;

    let password = '';  
    password += lowercase[Math.floor(Math.random() * lowercase.length)];  
    password += uppercase[Math.floor(Math.random() * uppercase.length)];  
    password += numbers[Math.floor(Math.random() * numbers.length)];  

    for (let i = 3; i < length; i++) {  
        const randomIndex = Math.floor(Math.random() * allCharacters.length);  
        password += allCharacters[randomIndex];  
    }  

    // Shuffle the password to mix the characters  
    password = password.split('').sort(() => 0.5 - Math.random()).join('');  

    return password;
}  
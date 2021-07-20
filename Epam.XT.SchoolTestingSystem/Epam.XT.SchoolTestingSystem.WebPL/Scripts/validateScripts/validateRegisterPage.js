const login = document.getElementById('login');
const password = document.getElementById('password');
const name = document.getElementById('textField1');
const surName = document.getElementById('textField2');
const validityStatePassword = password.validity;
const validityStateLogin = login.validity;
const nameStateLogin = name.validity;
const surNameStateLogin = surName.validity;

password.addEventListener('input', function (event) {

    if (validityStatePassword.valid) {
        password.setCustomValidity('');
    } else {
        showErrorPassword();
    }
    if (validityStateLogin.valid) {
        login.setCustomValidity('');
    } else {
        showErrorLogin();
    }
    if (nameStateLogin.valid) {
        name.setCustomValidity('');
    } else {
        showErrorName();
    }
    if (surNameStateLogin.valid) {
        surName.setCustomValidity('');
    } else {
        showErrorSurName();
    }
});
function showErrorPassword() {
    if (validityStatePassword.patternMismatch) {
        password.setCustomValidity('Пароль должен содержать цифры и буквы верхего и нижнего регистра латинского алфавита. Длина от 4 до 16 символов');
    }
    else {
        password.setCustomValidity('');
    }
}
function showErrorLogin() {
    if (validityStateLogin.patternMismatch) {
        login.setCustomValidity('Введите логин пользователя(от 4 до 16 символов)');
    }
    else {
        login.setCustomValidity('');
    }
}
function showErrorName() {
    if (nameStateLogin.patternMismatch) {
        name.setCustomValidity('Имя может содержать только буквы латиницы или кириллицы');
    }
    else {
        name.setCustomValidity('');
    }
}
function showErrorSurName() {
    if (surNameStateLogin.patternMismatch) {
        surName.setCustomValidity('Фамилия может содержать только буквы латиницы или кириллицы');
    }
    else {
        name.setCustomValidity('');
    }
}
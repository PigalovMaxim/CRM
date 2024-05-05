const loginInput = document.getElementById('js-auth-login');
const loginError = document.getElementById('js-auth-login-error');
const passwordInput = document.getElementById('js-auth-password');
const passwordError = document.getElementById('js-auth-password-error');
const submit = document.getElementById('js-auth-submit'); 

submit.addEventListener('click', e => {
    e.preventDefault();
    setErrors();
    const login = loginInput.value.trim();
    const isValid = validate(login, passwordInput.value.trim());
    if (!isValid) {
        return;
    }
    Store.setItem('user', login);
    window.location.replace("/home");
});

function setErrors(login, password) {
    if (login) {
        loginError.innerText = login;
        loginInput.classList.add('border-c-red');
        loginError.classList.remove('hidden');
    } else {
        loginInput.classList.remove('border-c-red');
        loginError.classList.add('hidden');
    }

    if (password) {
        passwordError.innerText = password;
        passwordInput.classList.add('border-c-red');
        passwordError.classList.remove('hidden');
        return;
    }

    passwordInput.classList.remove('border-c-red');
    passwordError.classList.add('hidden');
}

function validate(loginValue, passwordValue) {
    let loginErr = '';
    let passwordErr = '';

    if (!loginValue) {
        loginErr = 'Поле является обязательным';
    }
    if (!passwordValue) {
        passwordErr = 'Поле является обязательным';
    }

    if (loginErr || passwordErr) {
        setErrors(loginErr, passwordErr);
        return false;
    }

    return true;
}

const loginInput = document.getElementById('js-auth-login');
const loginError = document.getElementById('js-auth-login-error');
const passwordInput = document.getElementById('js-auth-password');
const passwordError = document.getElementById('js-auth-password-error');
const submit = document.getElementById('js-auth-submit'); 

submit.addEventListener('click', async (e) => {
    e.preventDefault();
    setErrors();
    const login = loginInput.value;
    const password = passwordInput.value;
    const isValid = validate(login, password);
    if (!isValid) {
        return;
    }
    const url = window.location.origin;
    const answer = await fetch(url + '/api/login/login', {
        method: 'POST',
        body: JSON.stringify({
            login,
            hash: MD5(login + password),
        }),
        headers: {
            'Content-Type': 'application/json'
        }
    });
    const result = await answer.json();
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
        loginErr = '���� �������� ������������';
    }
    if (!passwordValue) {
        passwordErr = '���� �������� ������������';
    }

    if (loginErr || passwordErr) {
        setErrors(loginErr, passwordErr);
        return false;
    }

    return true;
}

const usersSelect = document.getElementById('js-admin-users');
const workDaysContainer = document.getElementById('js-admin-work-days');

const createUserBtn = document.getElementById('js-admin-create-user');
const createUserLogin = document.getElementById('js-admin-user-login');
const createUserPassword = document.getElementById('js-admin-user-password');

const createTaskBtn = document.getElementById('js-admin-create-task');
const createTaskTitle = document.getElementById('js-admin-task-title');
const createTaskHours = document.getElementById('js-admin-task-hours');
const createTaskDescription = document.getElementById('js-admin-task-description');

const createWorkDayDay = document.getElementById('js-admin-workday-day');
const createWorkDayCount = document.getElementById('js-admin-workday-count');
const createWorkDayDescription = document.getElementById('js-admin-workday-description');
const createWorkDayButton = document.getElementById('js-admin-workday-button');

let selectedUserId = null;

init();

usersSelect.addEventListener('change', (e) => {
    selectedUserId = parseInt(e.target.value);
    init();
});

createWorkDayButton.addEventListener('click', createWorkDay);
async function createWorkDay() {
    let result = null;
    try {
        const url = window.location.origin;
        const answer = await fetch(url + '/api/Admin/CreateWorkDay', {
            method: 'POST',
            body: JSON.stringify({
                day: createWorkDayDay.value,
                count: createWorkDayCount.value,
                description: createWorkDayDescription.value,
                userId: selectedUserId,
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        result = await answer.json();
    } catch (e) {
        console.error('Ошибка сервера', e);
        return;
    }

    if (result) {
        createWorkDayDay.value = '';
        createWorkDayCount.value = '';
        createWorkDayDescription.value = '';
        return init();
    }

    console.error('Ошибка создания рабочего дня');
}

createTaskBtn.addEventListener('click', async () => {
    let result = null;
    try {
        const url = window.location.origin;
        const user = Store.getItem('user');
        const answer = await fetch(url + '/api/Admin/CreateTask', {
            method: 'POST',
            body: JSON.stringify({
                title: createTaskTitle.value,
                description: createTaskDescription.value,
                hours: createTaskHours.value,
                wastedHours: 0,
                creatorId: user.id

            }),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        result = await answer.json();
    } catch (e) {
        console.error('Ошибка сервера');
        return;
    }

    if (result) {
        createTaskTitle.value = '';
        createTaskHours.value = '';
        createTaskDescription.value = '';
    }

    console.error('Ошибка создания пользователя');
});

createUserBtn.addEventListener('click', async () => {
    let result = null;
    try {
        const url = window.location.origin;
        const answer = await fetch(url + '/api/Admin/CreateUser', {
            method: 'POST',
            body: JSON.stringify({
                login: createUserLogin.value,
                hash: MD5(createUserLogin.value + createUserPassword.value),
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        result = await answer.json();
    } catch (e) {
        console.error('Ошибка сервера');
        return;
    }

    if (result) {
        createUserLogin.value = '';
        createUserPassword.value = '';
        return init();
    }

    console.error('Ошибка создания пользователя');
});

async function init() {
    let result = null;
    try {
        const url = window.location.origin;
        const parameters = selectedUserId ? `?id=${selectedUserId}` : '';
        const answer = await fetch(url + '/api/Admin/GetAdminData' + parameters);
        result = await answer.json();
    } catch (e) {
        console.error('Ошибка сервера');
        return;
    }

    fillPage(result);
}

function fillPage(data) {
    fillUsers(data);
    fillWorkDays(data);
}

function fillUsers(data) {
    usersSelect.innerHTML = '';
    let users = '';
    if (!selectedUserId) {
        selectedUserId = data.users[0].id;
    }
    data.users.forEach(user => {
        const isSelected = selectedUserId === user.id;
        users += `<option class="bg-block" ${isSelected ? 'selected' : ''} value="${user.id}">${user.login}</option>`;
    });
    usersSelect.innerHTML = users;
}

function fillWorkDays(data) {
    const elements = Array.from(workDaysContainer.children);
    elements.forEach(element => {
        if (!element.classList.contains('js-not-delete')) {
            element.remove();
        }
    });

    data.workDays.forEach((day, i) => {
        const row = document.createElement('tr');
        row.classList = `px-4 h-14 ${i % 2 === 1 ? "bg-block" : ""} text-white`; 

        const indexCol = document.createElement('td');
        indexCol.classList.add('px-2');
        indexCol.innerHTML = i + 1;
        row.appendChild(indexCol);

        const dayCol = document.createElement('td');
        dayCol.classList.add('px-2');

        let date = new Date(day.day);
        let options = { year: 'numeric', month: 'long', day: 'numeric' };
        let formattedDate = date.toLocaleDateString("ru-RU", options);

        dayCol.innerHTML = formattedDate;
        row.appendChild(dayCol);

        const countCol = document.createElement('td');
        countCol.classList.add('px-2');
        countCol.innerHTML = day.count;
        row.appendChild(countCol);

        const descriptionCol = document.createElement('td');
        descriptionCol.classList.add('px-2');
        descriptionCol.innerHTML = day.description;
        row.appendChild(descriptionCol);

        workDaysContainer.prepend(row);
    });
}
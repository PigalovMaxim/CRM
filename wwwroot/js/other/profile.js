const createWorkDayDay = document.getElementById('js-profile-workday-day');
const createWorkDayCount = document.getElementById('js-profile-workday-count');
const createWorkDayDescription = document.getElementById('js-profile-workday-description');
const createWorkDayButton = document.getElementById('js-profile-workday-button');

createWorkDayButton.addEventListener('click', createWorkDay);
async function createWorkDay() {
    let result = null;
    try {
        const url = window.location.origin;
        const answer = await fetch(url + '/api/Profile/CreateWorkDay', {
            method: 'POST',
            body: JSON.stringify({
                day: createWorkDayDay.value,
                count: createWorkDayCount.value,
                description: createWorkDayDescription.value,
                userId: Store.getItem('user').id,
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
    }

    console.error('Ошибка создания рабочего дня');
}
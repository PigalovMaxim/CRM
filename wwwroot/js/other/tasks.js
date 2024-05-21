const tasksBtns = document.getElementsByClassName('js-tasks-take');
const tasks = document.getElementsByClassName('js-tasks-task');

const currentWrapper = document.getElementById('js-tasks-current');
const currentTitle = document.getElementById('js-tasks-current-title');
const currentHours = document.getElementById('js-tasks-current-hours');
const currentCreator = document.getElementById('js-tasks-current-creator');
const currentDescription = document.getElementById('js-tasks-current-description');

const id = Store.getItem('user').id;

for (const btn of tasksBtns) {
    const executorId = btn.getAttribute('data-executor');

    btn.addEventListener('click', () => {
        const taskId = btn.getAttribute('data-id');
        takeTask(taskId, executorId);
    });

    if (executorId == id) {
        btn.classList.add('bg-c-red', 'hover:bg-c-red-light');
        btn.innerHTML = 'Остановить задачу';    
    } else {
        btn.classList.add('bg-c-green', 'hover:bg-c-green-light');
        btn.innerHTML = 'Взять задачу';
    }
}

for (const task of tasks) {
    const executorId = task.getAttribute('data-executor');

    task.addEventListener('click', (e) => {
        if (e.target.classList.contains('js-tasks-take') && executorId == id) return;
        fillCurrentTask(task);
    });

    if (id == executorId) {
        fillCurrentTask(task);
    }
}

function fillCurrentTask(task) {
    const taskWastedHours = task.getAttribute('data-wasted');
    const taskHours = task.getAttribute('data-hours');
    const taskDescription = task.getAttribute('data-description');
    const taskCreatorName = task.getAttribute('data-creator');
    const taskTitle = task.getAttribute('data-title');

    currentWrapper.classList.remove('hidden');
    currentTitle.innerHTML = taskTitle;
    currentCreator.innerHTML = taskCreatorName;
    currentDescription.innerHTML = taskDescription;
    currentHours.innerHTML = `${taskWastedHours} часов из ${taskHours} часов`;
}

async function takeTask(taskId, executorId) {
    try {
        const url = window.location.origin;
        const action = executorId == id ? 'stopTask' : 'takeTask';
        const answer = await fetch(url + `/api/tasks/${action}?userId=${id}&taskId=${taskId}`);
        const result = await answer.json();
        if (result) {
            window.location.reload();
        }
    } catch (e) {
        console.error(e);
    }
}
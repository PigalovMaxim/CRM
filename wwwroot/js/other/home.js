const container = document.getElementById('js-home-container');
const widgetList = document.getElementById('js-home-widget-modal-list');
const modal = document.getElementById('js-home-modal');
const closeModal = document.getElementById('js-home-close-modal');

const WIDGETS_STYLES = [
    'w-3/10 h-home-widget-height',
    'w-3/10 h-home-widget-height',
]
const DAYS_COLORS = [
    'bg-c-green',
    'bg-c-red',
    'bg-yellow-500',
    'bg-purple-500',
    'bg-gray-400',
]
const LOADING_CLASSNAMES = 'w-full h-full flex flex-col justify-center items-center';
const MAIN_CLASSNAMES = 'w-full flex flex-row flex-wrap justify-start items-start';

if (!Store.getItem('widgetIds')) {
    Store.setItem('widgetIds', [0, 1]);
}

closeModal.addEventListener('click', () => {
    modal.classList.add('hidden');
});;

async function setWidgetList() {
    try {
        const url = window.location.origin;
        const answer = await fetch(url + '/api/home/getWidgetList');
        result = await answer.json();
        widgetList.innerHTML = '';

        result.forEach(widget => {
            const wrapper = document.createElement('div');
            wrapper.classList = 'w-full h-10 flex flex-row justify-between items-center mb-2';

            const title = document.createElement('span');
            title.classList = 'text-lg text-white';
            title.innerHTML = widget.widgetName;

            const btn = document.createElement('button');
            btn.classList = 'h-full aspect-square rounded-full text-3xl bg-c-green disabled:opacity-50 hover:bg-c-green-light text-white flex justify-center items-center';
            btn.innerHTML = '+';
            const list = Store.getItem('widgetIds');
            btn.addEventListener('click', () => {
                let list = Store.getItem('widgetIds');
                if (list.includes(widget.widgetId)) {
                    list = list.filter(id => id !== widget.widgetId);
                } else {
                    list.push(widget.widgetId);
                }
                Store.setItem('widgetIds', list);
                init();
            });

            wrapper.appendChild(title);
            wrapper.appendChild(btn);

            widgetList.appendChild(wrapper);
        });
    } catch (e) {
        console.error("Ошибка сервера", e);
        return;
    }
}

async function init() {
    setLoading();
    let result = [];
    try {
        const url = window.location.origin;
        const id = Store.getItem('user').id;
        const widgetIds = Store.getItem('widgetIds');
        const answer = await fetch(url + '/api/home/getWidgets', {
            method: 'POST',
            body: JSON.stringify({
                id,
                widgetIds,
            }),
            headers: {
                'Content-Type': 'application/json'
            }
        });
        result = await answer.json();
    } catch (e) {
        console.error("Ошибка сервера");
        return;
    }
    container.classList = MAIN_CLASSNAMES;
    container.innerHTML = '';
    if (result.length) {
        result.forEach(widget => {
            container.appendChild(new Widget(widget.typeId, widget).render());
        });

        const addWidgetButton = document.createElement('button');
        addWidgetButton.classList = 'w-3/10 h-home-widget-height p-gap cursor-pointer';
        const widgetButtonBody = document.createElement('div');
        widgetButtonBody.classList = 'hover:bg-block-highlighted/20 transition-colors w-full h-full border-2 border-dashed border-white/40 rounded-lg flex justify-center items-center';
        widgetButtonBody.innerHTML = '<img alt="add widget" src="/imgs/plus.png" className="w-40 h-40 opacity-40" />';
        addWidgetButton.appendChild(widgetButtonBody);
        addWidgetButton.addEventListener('click', () => modal.classList.remove('hidden'));

        container.appendChild(addWidgetButton);
        return;
    }
    container.classList.add('h-full', 'flex', 'flex-col', 'justify-center', 'items-center');

    const title = document.createElement('h1');
    title.classList = 'text-4xl text-white mb-4 font-bold';
    title.innerHTML = 'У вас нет виджетов';
    container.appendChild(title);

    const button = document.createElement('button');
    button.classList = 'w-60 h-10 bg-c-green hover:bg-c-green-light transition-colors text-white rounded-md flex justify-center items-center';
    button.innerHTML = 'Добавить';
    button.addEventListener('click', () => modal.classList.remove('hidden'));
    container.appendChild(button);
}

function setLoading() {
    container.classList = LOADING_CLASSNAMES;
    container.innerHTML = '<img src="/imgs/loading.png" alt="loading" class="w-5 h-5 animate-spin" />';
}

init();
setWidgetList();

class Widget {
    constructor(type, data) {
        this.type = type;
        this.data = data;
        this.classNames = WIDGETS_STYLES[type];
    }

    getWidgetName() {
        const wrapper = document.createElement('div');
        wrapper.classList = 'bg-block w-full h-full rounded-lg flex flex-col justify-start items-center p-8';

        const title = document.createElement('h2');
        title.classList = 'text-2xl text-white font-medium';
        title.innerHTML = this.data.name;

        wrapper.appendChild(title);
        return wrapper;
    }

    getWorkingWidget() {
        const wrapper = this.getWidgetName();

        const progressCount = (this.data.totalHours / this.data.planHours) * 100;

        const progress = getCircularProgress(300, '#01953F', 30, progressCount, `${this.data.totalHours}ч / ${this.data.planHours}ч`);
        const progressWrapper = document.createElement('div');
        progressWrapper.classList = 'w-full aspect-square mt-4 flex justify-center items-center';
        progressWrapper.appendChild(progress);
        wrapper.appendChild(progressWrapper);

        return wrapper;
    }

    getDaysWidget() {
        const wrapper = this.getWidgetName();

        const daysWrapper = document.createElement('div');
        daysWrapper.classList = 'w-full grid gap-gap grid-cols-7 mt-10';
        const startOfMonth = moment().startOf('month');
        const dayOfWeek = startOfMonth.day();
        for (let i = 0; i < dayOfWeek - 1; i++) {
            const dayWrapper = document.createElement('div');
            dayWrapper.classList = 'aspect-square flex justify-start items-start text-white px-1';
            daysWrapper.appendChild(dayWrapper);
        }
        this.data.days.forEach((day, i)=> {
            const dayWrapper = document.createElement('div');
            dayWrapper.classList = 'aspect-square flex justify-start items-start text-white px-1';
            dayWrapper.classList.add(DAYS_COLORS[day]);
            if (moment().date() === i + 1) {
                dayWrapper.classList.add('border-2', 'border-white');
            }
            dayWrapper.innerHTML = i + 1;
            daysWrapper.appendChild(dayWrapper);
        });
        wrapper.appendChild(daysWrapper);

        return wrapper;
    }

    getLayout(widgetType) {
        const wrapper = document.createElement('div');
        wrapper.classList.add('relative', 'p-gap');
        wrapper.classList.add(...this.classNames.split(' '));
        const closeBtn = document.createElement('button');
        closeBtn.classList = 'transition-colors text-white rounded-md flex justify-center items-center absolute right-4 top-4 w-7 h-7';
        closeBtn.innerHTML = '<img src="/imgs/plus.png" alt="cross" class="w-6 h-6 rotate-45" />';
        closeBtn.addEventListener('click', () => {
            const filtered = Store.getItem('widgetIds').filter(id => id !== widgetType);
            Store.setItem('widgetIds', filtered);
            init();
        });
        wrapper.appendChild(closeBtn);
        return wrapper;
    }

    render() {
        let layout = null;
        switch (this.type) {
            case 0:
                layout = this.getLayout(this.type);
                layout.appendChild(this.getWorkingWidget());
                return layout;
            case 1:
                layout = this.getLayout(this.type);
                layout.appendChild(this.getDaysWidget());
                return layout;
            default:
                return this.getLayout(-1);
        }
    }
}

function getCircularProgress(size, color, width, progress, progressStr) {
    const canvas = document.createElement('canvas');
    canvas.style.width = size + 'px';
    canvas.style.height = size + 'px';
    canvas.width = size;
    canvas.height = size;
    document.body.appendChild(canvas);
    const ctx = canvas.getContext('2d');

    const startAngle = -0.5 * Math.PI;
    const endAngle = 2 * Math.PI * progress / 100 + startAngle;

    ctx.beginPath();
    ctx.arc(size / 2, size / 2, size / 2 - width, startAngle, endAngle);
    ctx.lineWidth = width;
    ctx.strokeStyle = color;
    ctx.stroke();

    ctx.beginPath();
    ctx.arc(size / 2, size / 2, size / 2 - width, startAngle, 2 * Math.PI + startAngle);
    ctx.strokeStyle = color + "50";
    ctx.stroke();

    ctx.fillStyle = '#ffffff';
    ctx.font = '32px Arial';
    ctx.textAlign = 'center';
    ctx.textBaseline = 'middle';
    ctx.fillText(progressStr, canvas.width / 2, canvas.height / 2);

    return canvas;
}
const menu = document.getElementById("js-menu");
const layoutBody = document.getElementById("js-layout");
const logo = document.getElementById("js-logo-menu");
const logout = document.getElementById("js-logout");
const menuTogglers = document.getElementsByClassName("js-menu-toggle");
const menuButtons = document.getElementsByClassName("js-menu-button");

let isMenuOpen = false;

const BODY_OPENED_CLASS = "w-main-screen";
const BODY_CLOSED_CLASS = "w-main-screen-full";
const MENU_OPENED_CLASS = "w-side-menu";
const MENU_CLOSED_CLASS = "w-side-menu-closed";

closeMenu();

for (const toggler of menuTogglers) {
    toggler.addEventListener("click", () => {
    if (isMenuOpen) {
            closeMenu();
            return;
        }
        openMenu();
    });
}

for (const button of [...menuButtons, logo]) {
    button.addEventListener("click", () => {
        window.location.href = button.getAttribute("data-url");
    });
}

logout.addEventListener("click", () => {
    Store.removeItem('user');
    window.location.replace("/");
});

function closeMenu() {
    layoutBody.classList.remove(BODY_OPENED_CLASS);
    layoutBody.classList.add(BODY_CLOSED_CLASS);
    menu.classList.add(MENU_CLOSED_CLASS);
    menu.classList.remove(MENU_OPENED_CLASS);
    logo.classList.add('opacity-0');
    logout.querySelector('span').classList.add('hidden');
    isMenuOpen = false;

    for (const button of menuButtons) {
        button.classList.replace('justify-start', 'justify-center');
        var img = button.querySelector("img");
        var span = button.querySelector("span");

        img.classList.remove("mr-2");
        span.classList.remove("max-w-full");
        span.classList.add("max-w-0");
    }
}

function openMenu() {
    layoutBody.classList.add(BODY_OPENED_CLASS);
    layoutBody.classList.remove(BODY_CLOSED_CLASS);
    menu.classList.remove(MENU_CLOSED_CLASS);
    menu.classList.add(MENU_OPENED_CLASS);
    logo.classList.remove('opacity-0');
    logout.querySelector('span').classList.remove('hidden');
    isMenuOpen = true;

    for (const button of menuButtons) {
        button.classList.replace('justify-center', 'justify-start');
        var img = button.querySelector("img");
        var span = button.querySelector("span");

        img.classList.add("mr-2");
        span.classList.add("max-w-full");
        span.classList.remove("max-w-0");
    }
}
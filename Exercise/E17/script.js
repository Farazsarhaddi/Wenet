// تابع تنظیم کوکی
function setCookie(name, value, days) {
    const date = new Date();
    date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000)); // تنظیم تاریخ انقضا
    const expires = "expires=" + date.toUTCString();
    document.cookie = name + "=" + value + ";" + expires + ";path=/";
}

// تابع دریافت کوکی
function getCookie(name) {
    const cookies = document.cookie.split('; ');
    for (let cookie of cookies) {
        const [key, value] = cookie.split('=');
        if (key === name) {
            return value;
        }
    }
    return null;
}

// مدیریت تعداد بازدید
function updateVisitCount() {
    let visitCount = getCookie("visitCount");
    if (visitCount) {
        visitCount = parseInt(visitCount) + 1; // افزایش تعداد بازدید
    } else {
        visitCount = 1; // مقدار اولیه
    }

    // ذخیره تعداد بازدید در کوکی
    setCookie("visitCount", visitCount, 30); // ذخیره برای 30 روز

    // نمایش تعداد بازدید
    document.getElementById("visit-count").textContent = `You have visited this page ${visitCount} times.`;
}

// مدیریت تغییر تم
function toggleTheme() {
    let currentTheme = getCookie("theme");
    if (currentTheme === "dark") {
        document.body.classList.remove("dark-mode");
        document.body.classList.add("light-mode");
        setCookie("theme", "light", 7); // ذخیره تم روشن
    } else {
        document.body.classList.remove("light-mode");
        document.body.classList.add("dark-mode");
        setCookie("theme", "dark", 7); // ذخیره تم تاریک
    }
}

// بارگذاری تنظیمات اولیه
function initializePage() {
    // بارگذاری تعداد بازدید
    updateVisitCount();

    // بارگذاری تم
    const savedTheme = getCookie("theme") || "light"; // تم پیش‌فرض: روشن
    if (savedTheme === "dark") {
        document.body.classList.add("dark-mode");
    } else {
        document.body.classList.add("light-mode");
    }
}

// فراخوانی هنگام بارگذاری صفحه
window.onload = initializePage;

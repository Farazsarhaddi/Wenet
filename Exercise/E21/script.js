function fetchCatImage() {
    const responseCode = document.getElementById('responseCode').value;
    const catImage = document.getElementById('catImage');
    const message = document.getElementById('message');

    if (!responseCode) {
        message.textContent = "Please enter a valid response code.";
        catImage.style.display = "none";
        return;
    }

    // URL to fetch the image from IIS
    const url = `http://localhost:85/http-cats/${responseCode}.jpg`;

    // AJAX request to check if the image exists
    const xhr = new XMLHttpRequest();
    xhr.open("GET", url, true);
    xhr.onload = function () {
        if (xhr.status === 200) {
            catImage.src = url;
            catImage.style.display = "block";
            message.textContent = "";
        } else {
            message.textContent = `No cat image found for code ${responseCode}.`;
            catImage.style.display = "none";
        }
    };
    xhr.onerror = function () {
        message.textContent = "An error occurred while fetching the image.";
        catImage.style.display = "none";
    };
    xhr.send();
}

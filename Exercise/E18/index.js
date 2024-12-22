// Define the Line class
class Line {
    constructor(x1, y1, x2, y2) {
        this.x1 = x1;
        this.y1 = y1;
        this.x2 = x2;
        this.y2 = y2;
    }

    // Method to calculate the length of the line
    getLength() {
        const dx = this.x2 - this.x1;
        const dy = this.y2 - this.y1;
        return Math.sqrt(dx * dx + dy * dy);
    }
}

// Function to calculate line length
function calculateLength() {
    const x1 = parseFloat(document.getElementById('x1').value);
    const y1 = parseFloat(document.getElementById('y1').value);
    const x2 = parseFloat(document.getElementById('x2').value);
    const y2 = parseFloat(document.getElementById('y2').value);

    if (isNaN(x1) || isNaN(y1) || isNaN(x2) || isNaN(y2)) {
        document.getElementById('result').textContent = 'Please enter valid numbers';
        return;
    }

    const line = new Line(x1, y1, x2, y2);
    const length = line.getLength().toFixed(2);

    document.getElementById('result').textContent = `Line Length: ${length}`;
}

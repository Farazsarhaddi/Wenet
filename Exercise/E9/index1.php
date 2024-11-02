<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Prime Number Checker in PHP</title>
</head>
<body>
    <h2>Is the Number Prime?</h2>
    <form method="post" action="">
        <label>Enter a number:</label>
        <input type="number" name="number" required>
        <button type="submit">Check</button>
    </form>

    <?php
   
    function isPrime($num) {
        if ($num <= 1) {
            return false;
        }
        for ($i = 2; $i <= sqrt($num); $i++) {
            if ($num % $i == 0) {
                return false;
            }
        }
        return true;
    }

   
    if ($_SERVER["REQUEST_METHOD"] == "POST") {
        $number = $_POST['number'];
        if (isPrime($number)) {
            echo "<p>The number {$number} is a prime number.</p>";
        } else {
            echo "<p>The number {$number} is not a prime number.</p>";
        }
    }
    ?>
</body>
</html>

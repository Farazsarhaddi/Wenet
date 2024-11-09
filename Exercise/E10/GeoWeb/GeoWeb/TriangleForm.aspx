<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TriangleForm.aspx.cs" Inherits="GeoWeb.TriangleForm" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Triangle Perimeter Calculator</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f7fa;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        form {
            background-color: #fff;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
            width: 100%;
            max-width: 400px;
        }

        h2 {
            text-align: center;
            color: #333;
        }

        .input-group {
            margin-bottom: 20px;
        }

        label {
            font-weight: bold;
            display: block;
            margin-bottom: 8px;
            color: #555;
        }

        input[type="text"] {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            border-radius: 4px;
            border: 1px solid #ccc;
            font-size: 16px;
        }

        input[type="text"]:focus {
            outline: none;
            border-color: #007bff;
        }

        .button-group {
            display: flex;
            justify-content: center;
        }

        /* Custom Button CSS */
        .button {
            padding: 1rem 2rem;
            border-radius: 0.5rem;
            border: none;
            font-size: 1rem;
            font-weight: 400;
            color: #f4f0ff;
            text-align: center;
            position: relative;
            cursor: pointer;
            background-color: #007bff; /* Adjust button color if needed */
        }

        .button::before {
            content: "";
            display: block;
            position: absolute;
            left: 0;
            top: 0;
            height: 100%;
            width: 100%;
            border-radius: 0.5rem;
            background: linear-gradient(
                180deg,
                rgba(8, 77, 126, 0) 0%,
                rgba(8, 77, 126, 0.42) 100%
            ), rgba(47, 255, 255, 0.24);
            box-shadow: inset 0 0 12px rgba(151, 200, 255, 0.44);
            z-index: -1;
        }

        .button::after {
            content: "";
            display: block;
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: linear-gradient(
                180deg,
                rgba(8, 77, 126, 0) 0%,
                rgba(8, 77, 126, 0.42) 100%
            ), rgba(47, 255, 255, 0.24);
            box-shadow: inset 0 0 12px rgba(151, 200, 255, 0.44);
            border-radius: 0.5rem;
            opacity: 0;
            z-index: -1;
            transition: all 0.3s ease-in;
        }

        .button:hover::after {
            opacity: 1;
        }

        .button:active {
            transform: translateY(1px); /* Slightly move the button down on click */
            box-shadow: 0 4px 10px rgba(0, 123, 255, 0.3); /* Smaller shadow on click */
        }

        .result {
            text-align: center;
            font-size: 18px;
            margin-top: 20px;
            color: #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Triangle Perimeter Calculator</h2>
        <div class="input-group">
            <label for="txtLat1">Latitude 1:</label>
            <asp:TextBox ID="txtLat1" runat="server" placeholder="Enter Latitude 1" />
        </div>
        <div class="input-group">
            <label for="txtLon1">Longitude 1:</label>
            <asp:TextBox ID="txtLon1" runat="server" placeholder="Enter Longitude 1" />
        </div>
        <div class="input-group">
            <label for="txtLat2">Latitude 2:</label>
            <asp:TextBox ID="txtLat2" runat="server" placeholder="Enter Latitude 2" />
        </div>
        <div class="input-group">
            <label for="txtLon2">Longitude 2:</label>
            <asp:TextBox ID="txtLon2" runat="server" placeholder="Enter Longitude 2" />
        </div>
        <div class="input-group">
            <label for="txtLat3">Latitude 3:</label>
            <asp:TextBox ID="txtLat3" runat="server" placeholder="Enter Latitude 3" />
        </div>
        <div class="input-group">
            <label for="txtLon3">Longitude 3:</label>
            <asp:TextBox ID="txtLon3" runat="server" placeholder="Enter Longitude 3" />
        </div>
        <div class="button-group">
            <asp:Button ID="btnCalculate" runat="server" CssClass="button" Text="Calculate" OnClick="btnCalculate_Click" />
        </div>
        <div class="result">
            <asp:Label ID="lblResult" runat="server" Text="The perimeter will appear here." />
        </div>
    </form>
</body>
</html>

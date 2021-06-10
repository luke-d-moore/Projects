<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="MyChessBoard.HomePage" %>

	<link rel="stylesheet" href="/HomePage.css" type="text/css" />
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

	<script type="text/javascript" src="HomePage.js">
	</script>

<head runat="server">
    <title></title>
</head>
<body style="background-color:royalblue;">
    <form id="form1" runat="server">
			<div style="position:relative; left:500px;margin-top:25px;" runat="server">
				<h1>My ChessBoard</h1>
			</div>
			<input id="HTMLHiddenField" type="hidden" name="HTMLHiddenField"/>
			<input id="StartChessPieces" type="hidden" name="StartingChessPieces" runat ="server"/>
			<input id="CurrentChessPieces" type="hidden" name="CurrentChessPieces" runat ="server"/>
			<input id="EmptyBoard" type="hidden" name="EmptyBoard" runat="server"/>
		<div id="messagewithbutton">
		<span runat="server">To Setup the Start position please click Start Position button</span>
		<div>
			<button type="button" id="btnSetupStartPosition" onclick="startpos();">Start position</button>
		</div>
		</div>
			<div id="divChessBoard" runat="server"></div>
    </form>
</body>
</html>


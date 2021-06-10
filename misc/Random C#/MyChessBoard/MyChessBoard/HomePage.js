
function startpos() {
	ClearBoard();
	document.getElementById('a8').innerHTML = '<img src="/images/Black R.ico" >';
	document.getElementById('b8').innerHTML = '<img src="/images/Black N.ico" >';
	document.getElementById('c8').innerHTML = '<img src="/images/Black B.ico" >';
	document.getElementById('d8').innerHTML = '<img src="/images/Black Q.ico" >';
	document.getElementById('e8').innerHTML = '<img src="/images/Black K.ico" >';
	document.getElementById('f8').innerHTML = '<img src="/images/Black B.ico" >';
	document.getElementById('g8').innerHTML = '<img src="/images/Black N.ico" >';
	document.getElementById('h8').innerHTML = '<img src="/images/Black R.ico" >';
	document.getElementById('a7').innerHTML = '<img src="/images/Black P.ico" >';
	document.getElementById('b7').innerHTML = '<img src="/images/Black P.ico" >';
	document.getElementById('c7').innerHTML = '<img src="/images/Black P.ico" >';
	document.getElementById('d7').innerHTML = '<img src="/images/Black P.ico" >';
	document.getElementById('e7').innerHTML = '<img src="/images/Black P.ico" >';
	document.getElementById('f7').innerHTML = '<img src="/images/Black P.ico" >';
	document.getElementById('g7').innerHTML = '<img src="/images/Black P.ico" >';
	document.getElementById('h7').innerHTML = '<img src="/images/Black P.ico" >';
	document.getElementById('a1').innerHTML = '<img src="/images/White R.ico" >';
	document.getElementById('b1').innerHTML = '<img src="/images/White N.ico" >';
	document.getElementById('c1').innerHTML = '<img src="/images/White B.ico" >';
	document.getElementById('d1').innerHTML = '<img src="/images/White Q.ico" >';
	document.getElementById('e1').innerHTML = '<img src="/images/White K.ico" >';
	document.getElementById('f1').innerHTML = '<img src="/images/White B.ico" >';
	document.getElementById('g1').innerHTML = '<img src="/images/White N.ico" >';
	document.getElementById('h1').innerHTML = '<img src="/images/White R.ico" >';
	document.getElementById('a2').innerHTML = '<img src="/images/White P.ico" >';
	document.getElementById('b2').innerHTML = '<img src="/images/White P.ico" >';
	document.getElementById('c2').innerHTML = '<img src="/images/White P.ico" >';
	document.getElementById('d2').innerHTML = '<img src="/images/White P.ico" >';
	document.getElementById('e2').innerHTML = '<img src="/images/White P.ico" >';
	document.getElementById('f2').innerHTML = '<img src="/images/White P.ico" >';
	document.getElementById('g2').innerHTML = '<img src="/images/White P.ico" >';
	document.getElementById('h2').innerHTML = '<img src="/images/White P.ico" >';
}
function ClearBoard() {
	document.getElementById('divChessBoard').innerHTML = document.getElementById('EmptyBoard').value
}
function movepiece(square) {
	var ChessPiece = ChessPieceObj();

	if (ChessPiece.startSquare !== '') {

		if (ChessPiece.AvailableSquares.indexOf(square.id) !== -1) {
			document.getElementById(ChessPiece.startSquare).innerHTML = '';
			square.innerHTML = ChessPiece.image;
			if (ChessPiece.Move == 'White') {
				ChessPiece.Move = 'Black';
			}
			else {
				ChessPiece.Move = 'White';
			}
		}

		for (var j = 0; j <= ChessPiece.AvailableSquares.length - 1; j++) {
			var currentsquare = document.getElementById(ChessPiece.AvailableSquares[j]);
			currentsquare.style.borderColor = 'Black';
		}
		ChessPiece.startSquare = '';
		ChessPiece.image = '';
		ChessPiece.AvailableSquares = '';
		ChessPiece.piece = '';
		ChessPiece.ColourOfPiece = '';
		ChessPiece.FinishSquare = '';
	}
	else {
		var image = document.getElementById(square.id).innerHTML;
		ChessPiece.image = image;
		if (image != '' && image != null) {
			ChessPiece.startSquare = square.id;
			var legalmoves = LegalMovescsv(ChessPiece);
			if (legalmoves !== '') {
				legalmoves = chop(legalmoves);
				var legalsquares = legalmoves.split(',');
				ChessPiece.AvailableSquares = legalsquares;
				for (var j = 0; j <= (legalsquares.length - 1); j++) {
					var legalsquareid = '';
					var legalsquare = '';
					if (legalsquares[j] != '') {
						legalsquareid = document.getElementById(legalsquares[j]).id;
						legalsquare = document.getElementById(legalsquares[j]);
					}
					if (legalsquare != '' && legalsquare != null) {
						document.getElementById(legalsquareid).style.borderColor = 'Red';

					}
				}
			}
			else {
				ChessPiece.startSquare = '';
				ChessPiece.image = '';
				ChessPiece.AvailableSquares = '';
				ChessPiece.piece = '';
				ChessPiece.ColourOfPiece = '';
				ChessPiece.FinishSquare = '';
			}
		}

	}
	document.getElementById('HTMLHiddenField').value = JSON.stringify(ChessPiece);
}
function FileAndRankfunc(string) {
	return string.split('');
}
function chop(string) {
	var stringcharacters = string.split('');
	var newstring = '';
	for (var j = 0; j <= (string.length - 2); j++) {
		newstring += stringcharacters[j];
	}
	return newstring;
}
function ChessPieceObj() {
	var chessPiece = { piece: "", ColourOfPiece: "", AvailableSquares: "", startSquare: "", FinishSquare: "", image: "", Move: "White" };
	var hidden = document.getElementById('HTMLHiddenField');
	if (hidden.value != '') {
		return JSON.parse(hidden.value);
	}
	hidden.value = JSON.stringify(chessPiece);
	return chessPiece;
}
function LegalMovescsv(ChessPiece) {
	ChessPiece.ColourOfPiece = WhatColour(ChessPiece.image);
	if (ChessPiece.ColourOfPiece !== ChessPiece.Move) {
		return '';
	}
	ChessPiece.piece = WhatPiece(ChessPiece.image);

	return GetMoves(ChessPiece);

}
function WhatPiece(pieceimage) {
	if (pieceimage.indexOf('N.ico') !== -1) {
		return 'Knight';
	}
	else if (pieceimage.indexOf('B.ico') !== -1) {
		return 'Bishop';
	}
	else if (pieceimage.indexOf('R.ico') !== -1) {
		return 'Rook';
	}
	else if (pieceimage.indexOf('Q.ico') !== -1) {
		return 'Queen';
	}
	else if (pieceimage.indexOf('K.ico') !== -1) {
		return 'King';
	}
	else if (pieceimage.indexOf('P.ico') !== -1) {
		return 'Pawn';
	}
}
function WhatColour(pieceimage) {
	if (pieceimage.indexOf('White') !== -1) {
		return 'White';
	}
	else {
		return 'Black';
	}
}
function GetMoves(ChessPiece) {
	var Colour = ChessPiece.ColourOfPiece;
	var Piece = ChessPiece.piece;
	var FileAndRank = FileAndRankfunc(ChessPiece.startSquare);
	var LegalMovescsv = '';
	var files = 'a,b,c,d,e,f,g,h'.split(',');
	if (Piece == 'Knight') {
		LegalMovescsv = Knight(FileAndRank, Colour, files);
	}
	else if (Piece == 'Pawn') {
		LegalMovescsv = Pawn(FileAndRank, Colour, files);
	}
	else if (Piece == 'King') {
		LegalMovescsv = King(FileAndRank, Colour, files);
	}
	else if (Piece == 'Bishop') {
		LegalMovescsv = Bishop(FileAndRank, Colour, files);
	}
	else if (Piece == 'Rook') {
		LegalMovescsv = Rook(FileAndRank, Colour, files);
	}
	else if (Piece == 'Queen') {
		LegalMovescsv = Queen(FileAndRank, Colour, files);
	}

	return LegalMovescsv;
}

function Knight(FileAndRank, Colour, files) {
	var fileindex = files.indexOf(FileAndRank[0]);
	var AllMoves = '';
	if (fileindex <= files.length - 2) {
		if (FileAndRank[1] <= 6) {
			AllMoves += files[fileindex + 1] + (parseInt(FileAndRank[1]) + 2) + ',';
		}
		if (FileAndRank[1] >= 3) {
			AllMoves += files[fileindex + 1] + (parseInt(FileAndRank[1]) - 2) + ',';
		}
	}
	if (fileindex <= files.length - 3) {
		if (FileAndRank[1] <= 7) {
			AllMoves += files[fileindex + 2] + (parseInt(FileAndRank[1]) + 1) + ',';
		}
		if (FileAndRank[1] >= 2) {
			AllMoves += files[fileindex + 2] + (parseInt(FileAndRank[1]) - 1) + ',';
		}
	}
	if (fileindex - 1 >= 0) {
		if (FileAndRank[1] <= 6) {
			AllMoves += files[fileindex - 1] + (parseInt(FileAndRank[1]) + 2) + ',';
		}
		if (FileAndRank[1] >= 3) {
			AllMoves += files[fileindex - 1] + (parseInt(FileAndRank[1]) - 2) + ',';
		}
	}
	if (fileindex - 2 >= 0) {
		if (FileAndRank[1] <= 7) {
			AllMoves += files[fileindex - 2] + (parseInt(FileAndRank[1]) + 1) + ',';
		}
		if (FileAndRank[1] >= 2) {
			AllMoves += files[fileindex - 2] + (parseInt(FileAndRank[1]) - 1) + ',';
		}
	}
	var AvailableSquares = chop(AllMoves).split(',');
	var legalMoves = '';
	var ColourOfPieceOnFinishSquare = '';
	for (var j = 0; j <= (AvailableSquares.length - 1); j++) {
		if (AvailableSquares[j] != '') {
			if (document.getElementById(AvailableSquares[j]).innerHTML != '') {
				ColourOfPieceOnFinishSquare = WhatColour(document.getElementById(AvailableSquares[j]).innerHTML);
				if (ColourOfPieceOnFinishSquare != Colour) {
					legalMoves += AvailableSquares[j] + ',';
				}
			}
			else {
				legalMoves += AvailableSquares[j] + ',';
			}
		}

	}

	return legalMoves;
}
function Pawn(FileAndRank, Colour, files) {
	var fileindex = files.indexOf(FileAndRank[0]);
	var AllMoves = '';
	if (Colour == 'White') {
		if (FileAndRank[1] == 2 && document.getElementById(files[fileindex] + (parseInt(FileAndRank[1]) + 2)).innerHTML == '' && document.getElementById(files[fileindex] + (parseInt(FileAndRank[1]) + 1)).innerHTML == '') {
			AllMoves += files[fileindex] + (parseInt(FileAndRank[1]) + 2) + ',';
		}
		if (document.getElementById(files[fileindex] + (parseInt(FileAndRank[1]) + 1)).innerHTML == '') {
			AllMoves += files[fileindex] + (parseInt(FileAndRank[1]) + 1) + ',';
		}
		if (fileindex != 7) {
			if (document.getElementById(files[fileindex + 1] + (parseInt(FileAndRank[1]) + 1)).innerHTML != '') {
				AllMoves += files[fileindex + 1] + (parseInt(FileAndRank[1]) + 1) + ',';
			}
		}
		if (fileindex != 0) {
			if (document.getElementById(files[fileindex - 1] + (parseInt(FileAndRank[1]) + 1)).innerHTML != '') {
				AllMoves += files[fileindex - 1] + (parseInt(FileAndRank[1]) + 1) + ',';
			}
		}

	}
	else {
		if (FileAndRank[1] == 7 && document.getElementById(files[fileindex] + (parseInt(FileAndRank[1]) - 2)).innerHTML == '' && document.getElementById(files[fileindex] + (parseInt(FileAndRank[1]) - 1)).innerHTML == '') {
			AllMoves += files[fileindex] + (parseInt(FileAndRank[1]) - 2) + ',';
		}
		if (document.getElementById(files[fileindex] + (parseInt(FileAndRank[1]) - 1)).innerHTML == '') {
			AllMoves += files[fileindex] + (parseInt(FileAndRank[1]) - 1) + ',';
		}
		if (fileindex != 7) {
			if (document.getElementById(files[fileindex + 1] + (parseInt(FileAndRank[1]) - 1)).innerHTML != '') {
				AllMoves += files[fileindex + 1] + (parseInt(FileAndRank[1]) - 1) + ',';
			}
		}
		if (fileindex != 0) {
			if (document.getElementById(files[fileindex - 1] + (parseInt(FileAndRank[1]) - 1)).innerHTML != '') {
				AllMoves += files[fileindex - 1] + (parseInt(FileAndRank[1]) - 1) + ',';
			}
		}

	}
	var AvailableSquares = chop(AllMoves).split(',');
	var legalMoves = '';
	var ColourOfPieceOnFinishSquare = '';
	for (var j = 0; j <= (AvailableSquares.length - 1); j++) {
		if (AvailableSquares[j] != '') {
			if (document.getElementById(AvailableSquares[j]).innerHTML != '') {
				ColourOfPieceOnFinishSquare = WhatColour(document.getElementById(AvailableSquares[j]).innerHTML);
				if (ColourOfPieceOnFinishSquare != Colour) {
					legalMoves += AvailableSquares[j] + ',';
				}
			}
			else {
				legalMoves += AvailableSquares[j] + ',';
			}
		}

	}

	return legalMoves;
}
function Bishop(FileAndRank, Colour, files) {
	var fileindex = files.indexOf(FileAndRank[0]);
	var AllMoves = '';
	var CurrentRank = FileAndRank[1];
	var NorthEastMoves = '';
	var NorthWestMoves = '';
	var SouthEastMoves = '';
	var SouthWestMoves = '';
	var i = 0;
	while (fileindex + i <= 7 && parseInt(CurrentRank) + i <= 8) {
		var newsquare = files[fileindex + i] + (parseInt(CurrentRank) + i);
		if (FileAndRank[0] != files[fileindex + i] && FileAndRank[1] != (parseInt(CurrentRank) + i)) {
			NorthEastMoves += newsquare + ',';
		}
		i++;
	}
	i = 0;
	while (fileindex + i <= 7 && parseInt(CurrentRank) - i >= 1) {
		var newsquare = files[fileindex + i] + (parseInt(CurrentRank) - i);
		if (FileAndRank[0] != files[fileindex + i] && FileAndRank[1] != (parseInt(CurrentRank) - i)) {
			SouthEastMoves += newsquare + ',';
		}
		i++;
	}
	i = 0;
	while (fileindex - i >= 0 && parseInt(CurrentRank) - i >= 1) {
		var newsquare = files[fileindex - i] + (parseInt(CurrentRank) - i);
		if (FileAndRank[0] != files[fileindex - i] && FileAndRank[1] != (parseInt(CurrentRank) - i)) {
			SouthWestMoves += newsquare + ',';
		}
		i++;
	}
	i = 0;
	while (fileindex - i >= 0 && parseInt(CurrentRank) + i <= 8) {
		var newsquare = files[fileindex - i] + (parseInt(CurrentRank) + i);
		if (FileAndRank[0] != files[fileindex - i] && FileAndRank[1] != (parseInt(CurrentRank) + i)) {
			NorthWestMoves += newsquare + ',';
		}
		i++;
	}
	AllMoves = NorthEastMoves + NorthWestMoves + SouthEastMoves + SouthWestMoves;
	//setup while or for loops in each of the four directions to check for a piece on the square signifying the end of the line of sight and add squares to the csv until this is reached.
	return AllMoves;
}
function Rook(FileAndRank, Colour, files) {
	var fileindex = files.indexOf(FileAndRank[0]);
	var AllMoves = '';
	var CurrentRank = FileAndRank[1];
	var NorthMoves = '';
	var WestMoves = '';
	var EastMoves = '';
	var SouthMoves = '';
	var i = 0;
	while (parseInt(CurrentRank) + i <= 8) {
		var newsquare = files[fileindex] + (parseInt(CurrentRank) + i);
		if (FileAndRank[1] != (parseInt(CurrentRank) + i)) {
			NorthMoves += newsquare + ',';
		}
		i++;
	}
	i = 0;
	while (fileindex + i <= 7) {
		var newsquare = files[fileindex + i] + (parseInt(CurrentRank));
		if (FileAndRank[0] != files[fileindex + i]) {
			EastMoves += newsquare + ',';
		}
		i++;
	}
	i = 0;
	while (parseInt(CurrentRank) - i >= 1) {
		var newsquare = files[fileindex] + (parseInt(CurrentRank) - i);
		if (FileAndRank[1] != (parseInt(CurrentRank - i))) {
			SouthMoves += newsquare + ',';
		}
		i++;
	}
	i = 0;
	while (fileindex - i >= 0) {
		var newsquare = files[fileindex - i] + (parseInt(CurrentRank));
		if (FileAndRank[0] != files[fileindex - i]) {
			WestMoves += newsquare + ',';
		}
		i++;
	}
	AllMoves = NorthMoves + WestMoves + EastMoves + SouthMoves;

	return AllMoves;
}
function Queen(FileAndRank, Colour, files) {
	var LegalMoves = '';
	LegalMoves += Bishop(FileAndRank, Colour, files) + Rook(FileAndRank, Colour, files)
	return LegalMoves;
}
function King(FileAndRank, Colour, files) {
	return '';
}
# Chess Game

Welcome to the **Chess Game** project! This document provides information on how to play the game, its rules, features, and how to set it up.

---

## Table of Contents
1. [Introduction](#introduction)
2. [Features](#features)
3. [How to Play](#how-to-play)
4. [Game Rules](#game-rules)
5. [Installation](#installation)
6. [How to Run the Game](#how-to-run-the-game)
7. [Contributing](#contributing)
8. [License](#license)

---

## Introduction
Chess is a strategic board game played between two players. The objective of the game is to checkmate your opponent's king, putting it in a position where it cannot escape capture. This project offers a digital version of chess that adheres to the traditional rules of the game.

---

## Features
- Full implementation of standard chess rules.
- Interactive player-vs-player mode (PvP).
- Visual representation of the chessboard and pieces.
- Real-time validation of moves.
- Automatic detection of check, checkmate, and stalemate.
- Undo functionality (optional).
- Save and load game functionality (optional).

---

## How to Play
1. **Setup**: The chessboard consists of 64 squares arranged in an 8x8 grid. Each player starts with 16 pieces: 8 pawns, 2 rooks, 2 knights, 2 bishops, 1 queen, and 1 king.
2. **Turn-based Gameplay**:
   - Players alternate turns, with the white pieces going first.
   - On each turn, a player moves one of their pieces according to the rules of that piece (see below).
3. **Winning the Game**:
   - The game is won by putting the opponent's king in checkmate.
   - The game can also end in a draw under certain conditions (stalemate, threefold repetition, insufficient material, etc.).

---

## Game Rules
### Piece Movements
- **Pawn**: Moves forward one square but captures diagonally. On its first move, it can move two squares forward.
- **Rook**: Moves any number of squares in a straight line (horizontally or vertically).
- **Knight**: Moves in an "L" shape (two squares in one direction and one square perpendicular).
- **Bishop**: Moves diagonally any number of squares.
- **Queen**: Moves any number of squares in any direction (horizontally, vertically, or diagonally).
- **King**: Moves one square in any direction. Special move: castling.

### Special Rules
- **Promotion**: When a pawn reaches the opponent's back rank, it is promoted to a queen, rook, bishop, or knight.
- **Chaos Chess **: that you have to discover.

---

## Installation
### Prerequisites
- Unity
  
### Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/your-repo/chess-game.git

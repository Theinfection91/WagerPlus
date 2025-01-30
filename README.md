# WagerPlus Design Document

## Overview
**WagerPlus** is a Discord-based betting system designed to handle structured wagers on various events, such as competitive matches, individual duels, or custom scenarios. The bot manages betting pools, calculates odds dynamically, and tracks wagers placed by users.  

## Features
- **Fixed and Dynamic Betting Pools**  
  - Fixed pools have set odds that do not change.  
  - Dynamic pools adjust odds in real-time based on total bets.  
- **Flexible Betting Targets**  
  - Users can wager on teams, individuals, or custom-defined targets.  
- **Odds Calculation**  
  - Real-time adjustments based on wager distribution.  
- **Lottery System**  
  - Daily jackpot where users purchase tickets for a randomized draw.  

---

## Core Concepts

### **Betting Pools**
A **pool** represents a single betting instance where users place wagers on predefined choices. Each pool consists of:  
- **Choices**: The selectable outcomes users can bet on.  
- **Targets**: The entities (teams, players, etc.) that represent each choice.  
- **Wagers**: A list of bets placed by users.  
- **Odds**: The payout multipliers calculated based on bet distribution.  

### **Choices & Targets**
Each **choice** is linked to a **target**, which represents an entity involved in the wager.  
- A target can be a **team**, **player**, or any custom event option.  
- Choices specify the expected outcome (e.g., win/loss).  

Example:
```
Match: Team A vs Team B Choices:

"Team A Wins"
"Team B Wins"
```

### **Wagers**
- Users place a **wager** by selecting a choice and specifying an amount.  
- The wager amount contributes to the odds calculation.  

---

## Odds Calculation

### **Fixed Odds System**
- Odds remain constant regardless of bets placed.  
- Typically used for structured, pre-balanced betting.  

### **Dynamic Odds System**
- Odds shift based on total bet distribution.  
- Calculated as:
```
Odds = (Total Wagered on Opponent) / (Total Wagered on Current Choice)
```

- Higher betting activity on one side reduces its payout potential, making underdog bets more lucrative.  

Example:  
```
Total Bets on Team A: $500
Total Bets on Team B: $200
Odds for Team A: 200 / 500 = 0.4x (Lower payout due to more bets)
Odds for Team B: 500 / 200 = 2.5x (Higher payout due to fewer bets)
```

---

## Lottery System
A separate feature that allows users to buy lottery tickets for a daily jackpot draw.  
- Each ticket has a unique number.  
- The winning number is drawn randomly at a set time.  
- The jackpot grows based on ticket purchases.  

---

## Tech Stack
- **Language**: C# (.NET 9.0)  
- **Storage**: JSON-based data management  
- **Framework**: Discord.NET for bot interactions  
- **Hosting**: Docker on a Linux server  

---

## Notes
- Pools can support both **fixed** and **dynamic** odds systems.  
- Betting is not limited to traditional sports or games; it can apply to any structured event.  
- The lottery system functions independently of the main betting pools.  

---

## Author
*Designed by Chase Carter*


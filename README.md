# Wager Bot Design Document

## Overview
The Currency Bot is a companion bot for Ladderbot4, leveraging its Git repository storage data. The bot introduces a custom currency system for Discord servers, allowing members to earn and spend currency based on activity, league events, and admin-defined custom events. The bot focuses on interaction, fun, and server engagement while integrating closely with Ladderbot4's leagues and challenges. 

---

# **Everything below is subject to change as development continues.**

---

## Features

### Currency System
- **Base Currency**: Every member starts with a base amount of currency (e.g., 50).
- **Earning Mechanisms**:
  - **Message Activity**: Members earn currency for sending messages in the server.
  - **Passive Income**: Members earn a small amount of currency periodically for being active in the guild.
- **Spending Options**:
  - **Wagering on Challenges**: Members can bet on active challenges from Ladderbot4's leagues.
  - **League Bets**:
    - Bet on the winner of the league.
    - Bet on most wins or most losses for a team.
  - **Custom Events**: Admins can add events for members to bet on, such as other tournaments or competitions hosted on the server.

---

## Key Commands

### Admin Commands
1. **Add Currency**: Add currency to a specific member or all members.
   - Example: `/currency add <member> <amount>`
2. **Deduct Currency**: Remove currency from a specific member.
   - Example: `/currency deduct <member> <amount>`
3. **Set Custom Event**: Create a custom event for betting.
   - Example: `/event create <event_name> <details>`
4. **Manage Bets**: Close bets, declare winners, or adjust odds for events.
   - Example: `/bets close <event_id>`

### Member Commands
1. **Check Balance**: View your current currency balance.
   - Example: `/balance`
2. **Bet on Challenge**: Place a wager on an active challenge in Ladderbot4's leagues.
   - Example: `/bet challenge <challenge_id> <amount>`
3. **Bet on League Outcome**: Place bets on overall league outcomes.
   - Example: `/bet league <league_id> <team_id> <amount>`
4. **Bet on Custom Event**: Place bets on admin-defined events.
   - Example: `/bet event <event_id> <amount>`
5. **Wager/Bets Leaderboard**: View the top wagers and bets made.
   - Example: `/leaderboard`

---

## Data Integration with Ladderbot4

### Data Sources
- **Challenges Data**: Access active challenges from Ladderbot4's leagues via the Git repository.
- **League Data**: Pull league information (teams, standings, results) for betting purposes.

### Interaction
- The bot reads from Ladderbot4's Git repository for live data on leagues and challenges.
- Bets placed on challenges or leagues are dynamically updated based on Ladderbot4's outcomes.

---

## Database Design

### Tables
1. **Members**
   - `member_id`: Discord user ID.
   - `balance`: Current currency balance.
   - `total_earned`: Total currency earned.
   - `total_spent`: Total currency spent.

2. **Bets**
   - `bet_id`: Unique identifier for the bet.
   - `member_id`: ID of the member placing the bet.
   - `event_id`: Associated challenge/league/custom event.
   - `amount`: Currency wagered.
   - `outcome`: Result of the bet (e.g., `win`, `lose`).

3. **Events**
   - `event_id`: Unique identifier for the event.
   - `event_type`: Type of event (e.g., `challenge`, `league`, `custom`).
   - `details`: Description of the event.
   - `status`: Current status (`open`, `closed`, etc.).

---

## Future Enhancements
- **Shop System**: Allow members to purchase items or perks with their currency.
- **Daily Rewards**: Introduce a daily login reward for active members.
- **Odds and Multipliers**: Implement dynamic odds and multipliers for betting.
- **Integration with Other Games**: Extend support for other tournament data beyond Ladderbot4.

---

## Development Goals
1. Implement core currency and activity-based earning.
2. Add Ladderbot4 integration for league and challenge betting.
3. Develop custom event management and admin tools.
4. Test and refine betting mechanics and database integration.
5. Release v1.0 to a test server for feedback and improvements.

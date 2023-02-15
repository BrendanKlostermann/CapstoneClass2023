ECHO off

sqlcmd -S localhost -E -i ecgo_db.sql
sqlcmd -S localhost -E -i sp_deactivate_member.sql
sqlcmd -S localhost -E -i sp_reset_password.sql
sqlcmd -S localhost -E -i sp_select_game_roster_by_game_id.sql
sqlcmd -S localhost -E -i sp_select_member_by_email.sql
sqlcmd -S localhost -E -i sp_select_role_by_team_id_by_player_id.sql
sqlcmd -S localhost -E -i sp_select_team_by_team_id.sql
sqlcmd -S localhost -E -i sp_create_message.sql
sqlcmd -S localhost -E -i sp_insert_bio_by_user_id.sql
sqlcmd -S localhost -E -i sp_insert_score_by_game_id.sql
sqlcmd -S localhost -E -i sp_select_active_league_by_status.sql
sqlcmd -S localhost -E -i sp_select_all_leagues.sql
sqlcmd -S localhost -E -i sp_select_bio_by_user_id.sql
sqlcmd -S localhost -E -i sp_select_league_by_league_id.sql
sqlcmd -S localhost -E -i sp_select_league_by_league_id_and_member_id.sql
sqlcmd -S localhost -E -i sp_select_messages_by_user_id.sql
sqlcmd -S localhost -E -i sp_select_sports.sql
sqlcmd -S localhost -E -i sp_select_game_list.sql
sqlcmd -S localhost -E -i sp_select_game_details_by_game_id.sql
sqlcmd -S localhost -E -i FakeDataInsert.sql



rem server is localhost

ECHO .
ECHO if no errors appear DB was created
PAUSE
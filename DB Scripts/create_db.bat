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
sqlcmd -S localhost -E -i sp_select_team_members_by_member_id_and_team_id.sql
sqlcmd -S localhost -E -i sp_selecting_all_players_on_a_team_by_team_id.sql
sqlcmd -S localhost -E -i sp_select_all_sports.sql
sqlcmd -S localhost -E -i sp_add_league.sql
sqlcmd -S localhost -E -i sp_delete_league.sql
sqlcmd -S localhost -E -i sp_add_team_to_league.sql
sqlcmd -S localhost -E -i sp_select_members_by_name.sql
sqlcmd -S localhost -E -i sp_select_people_I_texted_by_user_id.sql
sqlcmd -S localhost -E -i sp_select_team_by_team_name.sql
sqlcmd -S localhost -E -i sp_user_create_team.sql



sqlcmd -S localhost -E -i DataFakes.sql




rem server is localhost

ECHO .
ECHO if no errors appear DB was created
PAUSE
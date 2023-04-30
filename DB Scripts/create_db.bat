ECHO off

sqlcmd -S localhost -E -i ecgo_db.sql
sqlcmd -S localhost -E -i zipcodes.sql
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
sqlcmd -S localhost -E -i sp_select_members_by_name.sql
sqlcmd -S localhost -E -i sp_select_people_I_texted_by_user_id.sql
sqlcmd -S localhost -E -i sp_user_create_team.sql
sqlcmd -S localhost -E -i sp_authenticate_member.sql
sqlcmd -S localhost -E -i sp_update_league.sql
sqlcmd -S localhost -E -i sp_user_create_account.sql
sqlcmd -S localhost -E -i sp_select_game_details_by_game_id.sql
sqlcmd -S localhost -E -i sp_reset_password_to_default.sql
sqlcmd -S localhost -E -i sp_insert_league_registration_by_league_id_by_activity.sql
sqlcmd -S localhost -E -i sp_select_leagues_by_sport_id.sql
sqlcmd -S localhost -E -i sp_select_member_by_id.sql
sqlcmd -S localhost -E -i sp_select_team_by_member_id.sql
sqlcmd -S localhost -E -i sp_update_user_bio.sql
sqlcmd -S localhost -E -i sp_update_user_profile_picture.sql
sqlcmd -S localhost -E -i sp_select_league_list_by_team_id.sql
sqlcmd -S localhost -E -i sp_select_game_list_by_team_id.sql
sqlcmd -S localhost -E -i sp_select_team_by_team_name.sql
sqlcmd -S localhost -E -i sp_select_sport_description_by_sportID.sql
sqlcmd -S localhost -E -i sp_insert_user_account.sql
sqlcmd -S localhost -E -i sp_insert_member_into_teamMember_by_teamID_and_memberID.sql
sqlcmd -S localhost -E -i sp_remove_a_player_from_team_by_member_id.sql
sqlcmd -S localhost -E -i sp_select_member_games.sql
sqlcmd -S localhost -E -i sp_select_member_practices.sql
sqlcmd -S localhost -E -i sp_select_member_tournament_games.sql
sqlcmd -S localhost -E -i sp_delete_team_equipment.sql
sqlcmd -S localhost -E -i sp_delete_team_from_tournament.sql
sqlcmd -S localhost -E -i sp_insert_team_equipment.sql
sqlcmd -S localhost -E -i sp_insert_team_to_tournament.sql
sqlcmd -S localhost -E -i sp_select_team_equipment_by_name_or_sport_name_by_team_id.sql
sqlcmd -S localhost -E -i sp_select_tournament.sql
sqlcmd -S localhost -E -i sp_select_tournament_team_by_tournament_id.sql
sqlcmd -S localhost -E -i sp_update_team_equipment.sql
sqlcmd -S localhost -E -i sp_select_all_tournaments.sql
sqlcmd -S localhost -E -i sp_insert_tournament.sql
sqlcmd -S localhost -E -i sp_open_or_close_tournament_registration_by_tournament_id.sql
sqlcmd -S localhost -E -i sp_select_tournament_by_id.sql
sqlcmd -S localhost -E -i sp_create_practice.sql
sqlcmd -S localhost -E -i sp_update_game_score_by_game_id.sql
sqlcmd -S localhost -E -i sp_select_game.sql
sqlcmd -S localhost -E -i sp_select_venue.sql
sqlcmd -S localhost -E -i sp_delete_member_availability.sql
sqlcmd -S localhost -E -i sp_insert_member_availability.sql
sqlcmd -S localhost -E -i sp_select_member_availability.sql
sqlcmd -S localhost -E -i sp_update_member_availability.sql
sqlcmd -S localhost -E -i sp_select_team_members_by_team_id.sql
sqlcmd -S localhost -E -i sp_select_score_by_game_id.sql
sqlcmd -S localhost -E -i sp_insert_game.sql
sqlcmd -S localhost -E -i sp_update_game.sql
sqlcmd -S localhost -E -i sp_deactivate_game.sql
sqlcmd -S localhost -E -i sp_add_member_to_team_by_member_id_and_team_id.sql
sqlcmd -S localhost -E -i sp_remove_season.sql
sqlcmd -S localhost -E -i sp_update_season.sql
sqlcmd -S localhost -E -i sp_select_seasons_by_league_id.sql
sqlcmd -S localhost -E -i sp_deactivate_own_team.sql
sqlcmd -S localhost -E -i sp_select_tournament_by_tournamentid.sql
sqlcmd -S localhost -E -i sp_deactivate_tournament.sql
sqlcmd -S localhost -E -i sp_select_members_by_name_and_or_email.sql
sqlcmd -S localhost -E -i sp_update_teamMember_to_bench_or_starter.sql
sqlcmd -S localhost -E -i sp_select_zip_code_details.sql
sqlcmd -S localhost -E -i sp_delete_game_roster_rows.sql
sqlcmd -S localhost -E -i sp_select_all_teams.sql
sqlcmd -S localhost -E -i sp_select_all_roles.sql
sqlcmd -S localhost -E -i sp_insert_venue.sql
sqlcmd -S localhost -E -i sp_add_team_to_league.sql
sqlcmd -S localhost -E -i sp_insert_league_request.sql
sqlcmd -S localhost -E -i sp_select_leagues_by_member_id.sql
sqlcmd -S localhost -E -i sp_select_request_by_league_id.sql
sqlcmd -S localhost -E -i sp_select_teams_by_league_id.sql
sqlcmd -S localhost -E -i sp_update_league_request_status_by_request_id.sql
sqlcmd -S localhost -E -i sp_update_registration_by_league_id.sql
sqlcmd -S localhost -E -i sp_update_tournament.sql
sqlcmd -S localhost -E -i sp_delete_practice.sql
sqlcmd -S localhost -E -i sp_select_all_practices.sql
sqlcmd -S localhost -E -i sp_select_owner_by_team_id.sql
sqlcmd -S localhost -E -i sp_select_tournament_games.sql
sqlcmd -S localhost -E -i sp_delete_generate_tournament_team.sql
sqlcmd -S localhost -E -i sp_generate_tournament_team.sql
sqlcmd -S localhost -E -i sp_activate_tournament.sql
sqlcmd -S localhost -E -i sp_select_roles_by_member_id.sql
sqlcmd -S localhost -E -i sp_select_venues.sql
sqlcmd -S localhost -E -i sp_insert_game_roster_member.sql
sqlcmd -S localhost -E -i sp_update_game_score_by_team_id.sql
sqlcmd -S localhost -E -i sp_insert_team_request.sql
sqlcmd -S localhost -E -i sp_insert_tournament_request.sql
sqlcmd -S localhost -E -i sp_update_team_request_status_by_request_id.sql
sqlcmd -S localhost -E -i sp_update_tournament_request_status_by_request_id.sql
sqlcmd -S localhost -E -i sp_create_league.sql
sqlcmd -S localhost -E -i sp_select_teams_by_member_id.sql
sqlcmd -S localhost -E -i sp_select_request_by_team_id.sql
sqlcmd -S localhost -E -i sp_select_request_by_tournament_id.sql



sqlcmd -S localhost -E -i sampleData.sql



rem server is localhost

ECHO .
ECHO if no errors appear DB was created
PAUSE
-- тригеры для таблицы WorkTeams
CREATE OR REPLACE FUNCTION pms.set_workteam_created_date()
RETURNS TRIGGER AS $$
BEGIN
    NEW."CreatedDate" = CURRENT_DATE;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER tr_workteam_set_created_date
BEFORE INSERT ON pms."WorkTeam"
FOR EACH ROW
EXECUTE FUNCTION pms.set_workteam_created_date();
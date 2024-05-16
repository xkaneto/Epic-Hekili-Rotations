local out = 0;
local numGroupMembers = GetNumGroupMembers();
local CDIDs = {
    102560,359844,191427,288613,12472,365350,190319,375087,10060,391109,152279,47568,384376,51271,212283,393961,383883,383882,
};
local Ally1 = \"" + AllyName1 + "\";
local Ally2 = \"" + AllyName2 + "\";
local Ally3 = \"" + AllyName3 + "\";
local Ally4 = \"" + AllyName4 + "\";

if numGroupMembers > 0 and numGroupMembers < 6 then
    for p = 1, numGroupMembers do
        local partymember = 'party' .. p
        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)
        local role = UnitGroupRolesAssigned(partymember)
        local hasPrescienceBuff = false;
        if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then
            if UnitName(partymember) == Ally1 then
                for i = 1, 25 do
                    local name,_,_,_,_,expiration = UnitAura(partymember, i)
                    if expiration ~= nil then
                        local resttime = expiration - GetTime()
                        if name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then
                            hasPrescienceBuff = true;
                            break
                        end
                    end
                end
                if hasPrescienceBuff == false then
                    out = p;
                    return out;
                end
            elseif UnitName(partymember) == Ally2 then
                for i = 1, 25 do
                    local name,_,_,_,_,expiration = UnitAura(partymember, i)
                    if expiration ~= nil then
                        local resttime = expiration - GetTime()
                        if name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then
                            hasPrescienceBuff = true;
                            break
                        end
                    end
                end
                if hasPrescienceBuff == false then
                    out = p;
                    return out;
                end
            elseif UnitName(partymember) == Ally3 then
                for i = 1, 25 do
                    local name,_,_,_,_,expiration = UnitAura(partymember, i)
                    if expiration ~= nil then
                        local resttime = expiration - GetTime()
                        if name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then
                            hasPrescienceBuff = true;
                            break
                        end
                    end
                end
                if hasPrescienceBuff == false then
                    out = p;
                    return out;
                end
            elseif UnitName(partymember) == Ally4 then
                for i = 1, 25 do
                    local name,_,_,_,_,expiration = UnitAura(partymember, i)
                    if expiration ~= nil then
                        local resttime = expiration - GetTime()
                        if name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then
                            hasPrescienceBuff = true;
                            break
                        end
                    end
                end
                if hasPrescienceBuff == false then
                    out = p;
                    return out;
                end
            elseif role == \"DAMAGER\" then
                for i = 1, 25 do
                    local name,_,_,_,_,expiration = UnitAura(partymember, i)
                    if expiration ~= nil then
                        local resttime = expiration - GetTime()
                        if name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then
                            hasPrescienceBuff = true;
                            break
                        end
                    end
                end
                if hasPrescienceBuff == false then
                    out = p;
                    return out;
                end
            end
        end
    end
    return out;
elseif numGroupMembers > 5 then
    for r = 1, numGroupMembers do
        local raidmember = 'raid' .. r
        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", raidmember)
        local role = UnitGroupRolesAssigned(raidmember)
        local hasPrescienceBuff = false;
        local hasCDBuff = false;
        if UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 then
            if UnitName(raidmember) == Ally1 then
                for i = 1, 25 do
                    local name,_,_,_,_,expiration = UnitAura(raidmember, i)
                    if expiration ~= nil then
                        local resttime = expiration - GetTime()
                        if name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then
                            hasPrescienceBuff = true;
                            break
                        end
                    end
                end
                if hasPrescienceBuff == false then
                    out = r;
                    return out;
                end
            elseif UnitName(raidmember) == Ally2 then
                for i = 1, 25 do
                    local name,_,_,_,_,expiration = UnitAura(raidmember, i)
                    if expiration ~= nil then
                        local resttime = expiration - GetTime()
                        if name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then
                            hasPrescienceBuff = true;
                            break
                        end
                    end
                end
                if hasPrescienceBuff == false then
                    out = r;
                    return out;
                end
            elseif UnitName(raidmember) == Ally3 then
                for i = 1, 25 do
                    local name,_,_,_,_,expiration = UnitAura(raidmember, i)
                    if expiration ~= nil then
                        local resttime = expiration - GetTime()
                        if name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then
                            hasPrescienceBuff = true;
                            break
                        end
                    end
                end
                if hasPrescienceBuff == false then
                    out = r;
                    return out;
                end
            elseif UnitName(raidmember) == Ally4 then
                for i = 1, 25 do
                    local name,_,_,_,_,expiration = UnitAura(raidmember, i)
                    if expiration ~= nil then
                        local resttime = expiration - GetTime()
                        if name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then
                            hasPrescienceBuff = true;
                            break
                        end
                    end
                end
                if hasPrescienceBuff == false then
                    out = r;
                    return out;
                end
            end
        end
    end
    return out;
end
return out;

--"\nlocal out = 0;\nlocal numGroupMembers = GetNumGroupMembers();\nlocal CDIDs = {\n\z102560,359844,191427,288613,12472,365350,190319,375087,10060,391109,152279,47568,384376,51271,212283,393961,383883,383882,\n};\nlocal Ally1 = \"" + AllyName1 + "\";\nlocal Ally2 = \"" + AllyName2 + "\";\nlocal Ally3 = \"" + AllyName3 + "\";\nlocal Ally4 = \"" + AllyName4 + "\";\n\nif numGroupMembers > 0 and numGroupMembers < 6 then\n\zfor p = 1, numGroupMembers do\n\z\zlocal partymember = 'party' .. p\n\z\zlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)\n\z\zlocal role = UnitGroupRolesAssigned(partymember)\n\z\zlocal hasPrescienceBuff = false;\n\z\zif UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then\n\z\z\zif UnitName(partymember) == Ally1 then\n\z\z\z\zfor i = 1, 25 do\n\z\z\z\z\zlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\z\z\z\z\zif expiration ~= nil then\n\z\z\z\z\z\zlocal resttime = expiration - GetTime()\n\z\z\z\z\z\zif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\z\z\z\z\z\z\zhasPrescienceBuff = true;\n\z\z\z\z\z\z\zbreak\n\z\z\z\z\z\zend\n\z\z\z\z\zend\n\z\z\z\zend\n\z\z\z\zif hasPrescienceBuff == false then\n\z\z\z\z\zout = p;\n\z\z\z\z\zreturn out;\n\z\z\z\zend\n\z\z\zelseif UnitName(partymember) == Ally2 then\n\z\z\z\zfor i = 1, 25 do\n\z\z\z\z\zlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\z\z\z\z\zif expiration ~= nil then\n\z\z\z\z\z\zlocal resttime = expiration - GetTime()\n\z\z\z\z\z\zif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\z\z\z\z\z\z\zhasPrescienceBuff = true;\n\z\z\z\z\z\z\zbreak\n\z\z\z\z\z\zend\n\z\z\z\z\zend\n\z\z\z\zend\n\z\z\z\zif hasPrescienceBuff == false then\n\z\z\z\z\zout = p;\n\z\z\z\z\zreturn out;\n\z\z\z\zend\n\z\z\zelseif UnitName(partymember) == Ally3 then\n\z\z\z\zfor i = 1, 25 do\n\z\z\z\z\zlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\z\z\z\z\zif expiration ~= nil then\n\z\z\z\z\z\zlocal resttime = expiration - GetTime()\n\z\z\z\z\z\zif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\z\z\z\z\z\z\zhasPrescienceBuff = true;\n\z\z\z\z\z\z\zbreak\n\z\z\z\z\z\zend\n\z\z\z\z\zend\n\z\z\z\zend\n\z\z\z\zif hasPrescienceBuff == false then\n\z\z\z\z\zout = p;\n\z\z\z\z\zreturn out;\n\z\z\z\zend\n\z\z\zelseif UnitName(partymember) == Ally4 then\n\z\z\z\zfor i = 1, 25 do\n\z\z\z\z\zlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\z\z\z\z\zif expiration ~= nil then\n\z\z\z\z\z\zlocal resttime = expiration - GetTime()\n\z\z\z\z\z\zif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\z\z\z\z\z\z\zhasPrescienceBuff = true;\n\z\z\z\z\z\z\zbreak\n\z\z\z\z\z\zend\n\z\z\z\z\zend\n\z\z\z\zend\n\z\z\z\zif hasPrescienceBuff == false then\n\z\z\z\z\zout = p;\n\z\z\z\z\zreturn out;\n\z\z\z\zend\n\z\z\zelseif role == \"DAMAGER\" then\n\z\z\z\zfor i = 1, 25 do\n\z\z\z\z\zlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\z\z\z\z\zif expiration ~= nil then\n\z\z\z\z\z\zlocal resttime = expiration - GetTime()\n\z\z\z\z\z\zif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\z\z\z\z\z\z\zhasPrescienceBuff = true;\n\z\z\z\z\z\z\zbreak\n\z\z\z\z\z\zend\n\z\z\z\z\zend\n\z\z\z\zend\n\z\z\z\zif hasPrescienceBuff == false then\n\z\z\z\z\zout = p;\n\z\z\z\z\zreturn out;\n\z\z\z\zend\n\z\z\zend\n\z\zend\n\zend\n\zreturn out;\nelseif numGroupMembers > 5 then\n\zfor r = 1, numGroupMembers do\n\z\zlocal raidmember = 'raid' .. r\n\z\zlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", raidmember)\n\z\zlocal role = UnitGroupRolesAssigned(raidmember)\n\z\zlocal hasPrescienceBuff = false;\n\z\zlocal hasCDBuff = false;\n\z\zif UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 then\n\z\z\zif UnitName(raidmember) == Ally1 then\n\z\z\z\zfor i = 1, 25 do\n\z\z\z\z\zlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\z\z\z\z\zif expiration ~= nil then\n\z\z\z\z\z\zlocal resttime = expiration - GetTime()\n\z\z\z\z\z\zif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\z\z\z\z\z\z\zhasPrescienceBuff = true;\n\z\z\z\z\z\z\zbreak\n\z\z\z\z\z\zend\n\z\z\z\z\zend\n\z\z\z\zend\n\z\z\z\zif hasPrescienceBuff == false then\n\z\z\z\z\zout = r;\n\z\z\z\z\zreturn out;\n\z\z\z\zend\n\z\z\zelseif UnitName(raidmember) == Ally2 then\n\z\z\z\zfor i = 1, 25 do\n\z\z\z\z\zlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\z\z\z\z\zif expiration ~= nil then\n\z\z\z\z\z\zlocal resttime = expiration - GetTime()\n\z\z\z\z\z\zif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\z\z\z\z\z\z\zhasPrescienceBuff = true;\n\z\z\z\z\z\z\zbreak\n\z\z\z\z\z\zend\n\z\z\z\z\zend\n\z\z\z\zend\n\z\z\z\zif hasPrescienceBuff == false then\n\z\z\z\z\zout = r;\n\z\z\z\z\zreturn out;\n\z\z\z\zend\n\z\z\zelseif UnitName(raidmember) == Ally3 then\n\z\z\z\zfor i = 1, 25 do\n\z\z\z\z\zlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\z\z\z\z\zif expiration ~= nil then\n\z\z\z\z\z\zlocal resttime = expiration - GetTime()\n\z\z\z\z\z\zif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\z\z\z\z\z\z\zhasPrescienceBuff = true;\n\z\z\z\z\z\z\zbreak\n\z\z\z\z\z\zend\n\z\z\z\z\zend\n\z\z\z\zend\n\z\z\z\zif hasPrescienceBuff == false then\n\z\z\z\z\zout = r;\n\z\z\z\z\zreturn out;\n\z\z\z\zend\n\z\z\zelseif UnitName(raidmember) == Ally4 then\n\z\z\z\zfor i = 1, 25 do\n\z\z\z\z\zlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\z\z\z\z\zif expiration ~= nil then\n\z\z\z\z\z\zlocal resttime = expiration - GetTime()\n\z\z\z\z\z\zif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\z\z\z\z\z\z\zhasPrescienceBuff = true;\n\z\z\z\z\z\z\zbreak\n\z\z\z\z\z\zend\n\z\z\z\z\zend\n\z\z\z\zend\n\z\z\z\zif hasPrescienceBuff == false then\n\z\z\z\z\zout = r;\n\z\z\z\z\zreturn out;\n\z\z\z\zend\n\z\z\zend\n\z\zend\n\zend\n\zreturn out;\nend\nreturn out;"
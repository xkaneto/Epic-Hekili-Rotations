local out = 0;
local numGroupMembers = GetNumGroupMembers();
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

--"\nlocal out = 0;\nlocal numGroupMembers = GetNumGroupMembers();\nlocal Ally1 = \"" + AllyName1 + "\";\nlocal Ally2 = \"" + AllyName2 + "\";\nlocal Ally3 = \"" + AllyName3 + "\";\nlocal Ally4 = \"" + AllyName4 + "\";\n\nif numGroupMembers > 0 and numGroupMembers < 6 then\n\tfor p = 1, numGroupMembers do\n\t\tlocal partymember = 'party' .. p\n\t\tlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)\n\t\tlocal role = UnitGroupRolesAssigned(partymember)\n\t\tlocal hasPrescienceBuff = false;\n\t\tif UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then\n\t\t\tif UnitName(partymember) == Ally1 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(partymember) == Ally2 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(partymember) == Ally3 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(partymember) == Ally4 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif role == \"DAMAGER\" then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(partymember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = p;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\tend\n\t\tend\n\tend\n\treturn out;\nelseif numGroupMembers > 5 then\n\tfor r = 1, numGroupMembers do\n\t\tlocal raidmember = 'raid' .. r\n\t\tlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", raidmember)\n\t\tlocal role = UnitGroupRolesAssigned(raidmember)\n\t\tlocal hasPrescienceBuff = false;\n\t\tlocal hasCDBuff = false;\n\t\tif UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 then\n\t\t\tif UnitName(raidmember) == Ally1 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(raidmember) == Ally2 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(raidmember) == Ally3 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\telseif UnitName(raidmember) == Ally4 then\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name,_,_,_,_,expiration = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration ~= nil then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif name ~= nil and resttime > 6 and name == \"" + Prescience_SpellName(Language) + "\" then\n\t\t\t\t\t\t\thasPrescienceBuff = true;\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif hasPrescienceBuff == false then\n\t\t\t\t\tout = r;\n\t\t\t\t\treturn out;\n\t\t\t\tend\n\t\t\tend\n\t\tend\n\tend\n\treturn out;\nend\nreturn out;"
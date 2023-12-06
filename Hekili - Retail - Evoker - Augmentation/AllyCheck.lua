local out = 0;
local numGroupMembers = GetNumGroupMembers();
local CDIDs = {
    102560,359844,191427,288613,12472,365350,190319,375087,10060,391109,152279,47568,384376,51271,212283,393961,383883,383882,
};

if numGroupMembers > 0 and numGroupMembers < 6 then
    for p = 1, numGroupMembers do
        local partymember = 'party' .. p
        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)
        local role = UnitGroupRolesAssigned(partymember)
        if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then
            if (GetUnitName(partymember) == \"" + AllyName1 + "\" or GetUnitName(partymember) == \"" + AllyName2 + "\" or GetUnitName(partymember) == \"" + AllyName3 + "\" or GetUnitName(partymember) == \"" + AllyName4 + "\") then
                local hasPrescienceBuff = false
                local hasCDBuff = false
                for j = 1, 25 do
                    local _, _, _, _, _, _, _, _, _, buffid = UnitAura(partymember, j)
                    if buffid and tContains(CDIDs, buffid) then
                        hasCDBuff = true
                        break
                    end
                end
                for i = 1, 25 do
                    local name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(partymember, i)
                    if expiration > 0 then
                        local resttime = expiration - GetTime()
                        if resttime > 6 and buffid == 410089 and source == 'player' then
                            hasPrescienceBuff = true
                            break
                        end
                    end
                end
                if not hasPrescienceBuff and hasCDBuff then
                    out = p
                    break
                end
            else
                local hasPrescienceBuff = false
                local hasCDBuff = false
                for j = 1, 25 do
                    local _, _, _, _, _, _, _, _, _, buffid = UnitAura(partymember, j)
                    if buffid and tContains(CDIDs, buffid) then
                        hasCDBuff = true
                        break
                    end
                end
                for i = 1, 25 do
                    local name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(partymember, i)
                    if expiration > 0 then
                        local resttime = expiration - GetTime()
                        if resttime > 6 and buffid == 410089 and source == 'player' then
                            hasPrescienceBuff = true
                            break
                        end
                    end
                end
                if not hasPrescienceBuff and hasCDBuff then
                    out = p
                    break
                end
            end
            if (GetUnitName(partymember) == \"" + AllyName1 + "\" or GetUnitName(partymember) == \"" + AllyName2 + "\" or GetUnitName(partymember) == \"" + AllyName3 + "\" or GetUnitName(partymember) == \"" + AllyName4 + "\") then
                local hasPrescienceBuff = false
                for i = 1, 25 do
                    local name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(partymember, i)
                    if expiration > 0 then
                        local resttime = expiration - GetTime()
                        if resttime > 6 and buffid == 410089 and source == 'player' then
                            hasPrescienceBuff = true
                            break
                        end
                    end
                end
                if not hasPrescienceBuff then
                    out = p
                    break
                end
            end
            if (role == \"DAMAGER\") then
                local hasPrescienceBuff = false
                for i = 1, 25 do
                    local name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(partymember, i)
                    if expiration > 0 then
                        local resttime = expiration - GetTime()
                        if resttime > 6 and buffid == 410089 and source == 'player' then
                            hasPrescienceBuff = true
                            break
                        end
                    end
                end
                if not hasPrescienceBuff then
                    out = p
                    break
                end
            end
        end
    end
elseif numGroupMembers > 5 then
    for r = 1, numGroupMembers do
        local raidmember = 'raid' .. r
        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", raidmember)
        local role = UnitGroupRolesAssigned(raidmember)
        if UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 then
            if (GetUnitName(raidmember) == \"" + AllyName1 + "\" or GetUnitName(raidmember) == \"" + AllyName2 + "\" or GetUnitName(raidmember) == \"" + AllyName3 + "\" or GetUnitName(raidmember) == \"" + AllyName4 + "\") then
                local hasPrescienceBuff = false
                local hasCDBuff = false
                for j = 1, 25 do
                    local _, _, _, _, _, _, _, _, _, buffid = UnitAura(raidmember, j)
                    if buffid and tContains(CDIDs, buffid) then
                        hasCDBuff = true
                        break
                    end
                end
                for i = 1, 25 do
                    local name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(raidmember, i)
                    if expiration > 0 then
                        local resttime = expiration - GetTime()
                        if resttime > 6 and buffid == 410089 and source == 'player' then
                            hasPrescienceBuff = true
                            break
                        end
                    end
                end
                if not hasPrescienceBuff and hasCDBuff then
                    out = r
                    break
                end
            else
                local hasPrescienceBuff = false
                local hasCDBuff = false
                for j = 1, 25 do
                    local _, _, _, _, _, _, _, _, _, buffid = UnitAura(raidmember, j)
                    if buffid and tContains(CDIDs, buffid) then
                        hasCDBuff = true
                        break
                    end
                end
                for i = 1, 25 do
                    local name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(raidmember, i)
                    if expiration > 0 then
                        local resttime = expiration - GetTime()
                        if resttime > 6 and buffid == 410089 and source == 'player' then
                            hasPrescienceBuff = true
                            break
                        end
                    end
                end
                if not hasPrescienceBuff and hasCDBuff then
                    out = r
                    break
                end
            end
            if (GetUnitName(raidmember) == \"" + AllyName1 + "\" or GetUnitName(raidmember) == \"" + AllyName2 + "\" or GetUnitName(raidmember) == \"" + AllyName3 + "\" or GetUnitName(raidmember) == \"" + AllyName4 + "\") then
                local hasPrescienceBuff = false
                for i = 1, 25 do
                    local name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(raidmember, i)
                    if expiration > 0 then
                        local resttime = expiration - GetTime()
                        if resttime > 6 and buffid == 410089 and source == 'player' then
                            hasPrescienceBuff = true
                            break
                        end
                    end
                end
                if not hasPrescienceBuff then
                    out = r
                    break
                end
            end
            if (role == \"DAMAGER\") then
                local hasPrescienceBuff = false
                for i = 1, 25 do
                    local name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(raidmember, i)
                    if expiration > 0 then
                        local resttime = expiration - GetTime()
                        if resttime > 6 and buffid == 410089 and source == 'player' then
                            hasPrescienceBuff = true
                            break
                        end
                    end
                end
                if not hasPrescienceBuff then
                    out = r
                    break
                end
            end
        end
    end
end
return out;

--"local out = 0;\nlocal numGroupMembers = GetNumGroupMembers();\nlocal CDIDs = {\n\t102560,359844,191427,288613,12472,365350,190319,375087,10060,391109,152279,47568,384376,51271,212283,393961,383883,383882,\n};\n\nif numGroupMembers > 0 and numGroupMembers < 6 then\n\tfor p = 1, numGroupMembers do\n\t\tlocal partymember = 'party' .. p\n\t\tlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)\n\t\tlocal role = UnitGroupRolesAssigned(partymember)\n\t\tif UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then\n\t\t\tif (GetUnitName(partymember) == \"" + AllyName1 + "\" or GetUnitName(partymember) == \"" + AllyName2 + "\" or GetUnitName(partymember) == \"" + AllyName3 + "\" or GetUnitName(partymember) == \"" + AllyName4 + "\") then\n\t\t\t\tlocal hasPrescienceBuff = false\n\t\t\t\tlocal hasCDBuff = false\n\t\t\t\tfor j = 1, 25 do\n\t\t\t\t\tlocal _, _, _, _, _, _, _, _, _, buffid = UnitAura(partymember, j)\n\t\t\t\t\tif buffid and tContains(CDIDs, buffid) then\n\t\t\t\t\t\thasCDBuff = true\n\t\t\t\t\t\tbreak\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(partymember, i)\n\t\t\t\t\tif expiration > 0 then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif resttime > 6 and buffid == 410089 and source == 'player' then\n\t\t\t\t\t\t\thasPrescienceBuff = true\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif not hasPrescienceBuff and hasCDBuff then\n\t\t\t\t\tout = p\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\telse\n\t\t\t\tlocal hasPrescienceBuff = false\n\t\t\t\tlocal hasCDBuff = false\n\t\t\t\tfor j = 1, 25 do\n\t\t\t\t\tlocal _, _, _, _, _, _, _, _, _, buffid = UnitAura(partymember, j)\n\t\t\t\t\tif buffid and tContains(CDIDs, buffid) then\n\t\t\t\t\t\thasCDBuff = true\n\t\t\t\t\t\tbreak\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(partymember, i)\n\t\t\t\t\tif expiration > 0 then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif resttime > 6 and buffid == 410089 and source == 'player' then\n\t\t\t\t\t\t\thasPrescienceBuff = true\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif not hasPrescienceBuff and hasCDBuff then\n\t\t\t\t\tout = p\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif (GetUnitName(partymember) == \"" + AllyName1 + "\" or GetUnitName(partymember) == \"" + AllyName2 + "\" or GetUnitName(partymember) == \"" + AllyName3 + "\" or GetUnitName(partymember) == \"" + AllyName4 + "\") then\n\t\t\t\tlocal hasPrescienceBuff = false\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(partymember, i)\n\t\t\t\t\tif expiration > 0 then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif resttime > 6 and buffid == 410089 and source == 'player' then\n\t\t\t\t\t\t\thasPrescienceBuff = true\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif not hasPrescienceBuff then\n\t\t\t\t\tout = p\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif (role == \"DAMAGE\") then\n\t\t\t\tlocal hasPrescienceBuff = false\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(partymember, i)\n\t\t\t\t\tif expiration > 0 then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif resttime > 6 and buffid == 410089 and source == 'player' then\n\t\t\t\t\t\t\thasPrescienceBuff = true\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif not hasPrescienceBuff then\n\t\t\t\t\tout = p\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\tend\n\tend\nelseif numGroupMembers > 5 then\n\tfor r = 1, numGroupMembers do\n\t\tlocal raidmember = 'raid' .. r\n\t\tlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", raidmember)\n\t\tlocal role = UnitGroupRolesAssigned(raidmember)\n\t\tif UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 then\n\t\t\tif (GetUnitName(raidmember) == \"" + AllyName1 + "\" or GetUnitName(raidmember) == \"" + AllyName2 + "\" or GetUnitName(raidmember) == \"" + AllyName3 + "\" or GetUnitName(raidmember) == \"" + AllyName4 + "\") then\n\t\t\t\tlocal hasPrescienceBuff = false\n\t\t\t\tlocal hasCDBuff = false\n\t\t\t\tfor j = 1, 25 do\n\t\t\t\t\tlocal _, _, _, _, _, _, _, _, _, buffid = UnitAura(raidmember, j)\n\t\t\t\t\tif buffid and tContains(CDIDs, buffid) then\n\t\t\t\t\t\thasCDBuff = true\n\t\t\t\t\t\tbreak\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration > 0 then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif resttime > 6 and buffid == 410089 and source == 'player' then\n\t\t\t\t\t\t\thasPrescienceBuff = true\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif not hasPrescienceBuff and hasCDBuff then\n\t\t\t\t\tout = r\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\telse\n\t\t\t\tlocal hasPrescienceBuff = false\n\t\t\t\tlocal hasCDBuff = false\n\t\t\t\tfor j = 1, 25 do\n\t\t\t\t\tlocal _, _, _, _, _, _, _, _, _, buffid = UnitAura(raidmember, j)\n\t\t\t\t\tif buffid and tContains(CDIDs, buffid) then\n\t\t\t\t\t\thasCDBuff = true\n\t\t\t\t\t\tbreak\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration > 0 then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif resttime > 6 and buffid == 410089 and source == 'player' then\n\t\t\t\t\t\t\thasPrescienceBuff = true\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif not hasPrescienceBuff and hasCDBuff then\n\t\t\t\t\tout = r\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif (GetUnitName(raidmember) == \"" + AllyName1 + "\" or GetUnitName(raidmember) == \"" + AllyName2 + "\" or GetUnitName(raidmember) == \"" + AllyName3 + "\" or GetUnitName(raidmember) == \"" + AllyName4 + "\") then\n\t\t\t\tlocal hasPrescienceBuff = false\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration > 0 then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif resttime > 6 and buffid == 410089 and source == 'player' then\n\t\t\t\t\t\t\thasPrescienceBuff = true\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif not hasPrescienceBuff then\n\t\t\t\t\tout = r\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif (role == \"DAMAGE\") then\n\t\t\t\tlocal hasPrescienceBuff = false\n\t\t\t\tfor i = 1, 25 do\n\t\t\t\t\tlocal name, _, _, _, _, expiration, source, _, _, buffid = UnitAura(raidmember, i)\n\t\t\t\t\tif expiration > 0 then\n\t\t\t\t\t\tlocal resttime = expiration - GetTime()\n\t\t\t\t\t\tif resttime > 6 and buffid == 410089 and source == 'player' then\n\t\t\t\t\t\t\thasPrescienceBuff = true\n\t\t\t\t\t\t\tbreak\n\t\t\t\t\t\tend\n\t\t\t\t\tend\n\t\t\t\tend\n\t\t\t\tif not hasPrescienceBuff then\n\t\t\t\t\tout = r\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\tend\n\tend\nend\nreturn out;"
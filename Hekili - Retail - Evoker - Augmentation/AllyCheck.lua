local out = 0
local numGroupMembers = GetNumGroupMembers()

if UnitExists('mouseover') then
    if  UnitIsPlayer('mouseover') ~= true and IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", 'mouseover') == 1 and (GetUnitName('mouseover') == \"" + AllyName1 + "\" or GetUnitName('mouseover') == \"" + AllyName2 + "\" or GetUnitName('mouseover') == \"" + AllyName3 + "\" or GetUnitName('mouseover') == \"" + AllyName4 + "\") then
        out = 100
    end
end

if numGroupMembers > 0 and numGroupMembers < 6 then
    for p = 1, numGroupMembers do
        local partymember = 'party' .. p
        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)
        if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 and (GetUnitName(partymember) == \"" + AllyName1 + "\" or GetUnitName(partymember) == \"" + AllyName2 + "\" or GetUnitName(partymember) == \"" + AllyName3 + "\" or GetUnitName(partymember) == \"" + AllyName4 + "\") then
            local hasPrescienceBuff = false
            for i = 1, 25 do
                local name, _, _, _, _, _, source = UnitAura(partymember, i)
                if name == \"" + Prescience_SpellName(Language) + "\" and source == 'player' then
                    hasPrescienceBuff = true
                    break
                end
            end
            if not hasPrescienceBuff then
                out = p
                break
            end
        end
    end
elseif numGroupMembers > 5 then
    for r = 1, numGroupMembers do
        local raidmember = 'raid' .. r
        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", raidmember)
        if UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 and (GetUnitName(raidmember) == \"" + AllyName1 + "\" or GetUnitName(raidmember) == \"" + AllyName2 + "\" or GetUnitName(raidmember) == \"" + AllyName3 + "\" or GetUnitName(raidmember) == \"" + AllyName4 + "\") then
            local hasPrescienceBuff = false
            for i = 1, 25 do
                local name, _, _, _, _, _, source = UnitAura(raidmember, i)
                if name == \"" + Prescience_SpellName(Language) + "\" and source == 'player' then
                    hasPrescienceBuff = true
                    break
                end
            end
            if not hasPrescienceBuff then
                out = r
                break
            end
        end
    end
end

return out

--"local out = 0\nlocal numGroupMembers = GetNumGroupMembers()\n\nif UnitExists('mouseover') then\n\tif  UnitIsPlayer('mouseover') ~= true and IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", 'mouseover') == 1 and (GetUnitName('mouseover') == \"" + AllyName1 + "\" or GetUnitName('mouseover') == \"" + AllyName2 + "\" or GetUnitName(raidmember) == \"" + AllyName3 + "\" or GetUnitName(raidmember) == \"" + AllyName4 + "\") then\n\t\tout = 100\n\tend\nend\n\nif numGroupMembers > 0 and numGroupMembers < 6 then\n\tfor p = 1, numGroupMembers do\n\t\tlocal partymember = 'party' .. p\n\t\tlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)\n\t\tif UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 and (GetUnitName(partymember) == \"" + AllyName1 + "\" or GetUnitName(partymember) == \"" + AllyName2 + "\" or GetUnitName(raidmember) == \"" + AllyName3 + "\" or GetUnitName(raidmember) == \"" + AllyName4 + "\") then\n\t\t\tlocal hasPrescienceBuff = false\n\t\t\tfor i = 1, 25 do\n\t\t\t\tlocal name, _, _, _, _, _, source = UnitAura(partymember, i)\n\t\t\t\tif name == \"" + Prescience_SpellName(Language) + "\" and source == 'player' then\n\t\t\t\t\thasPrescienceBuff = true\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif not hasPrescienceBuff then\n\t\t\t\tout = p\n\t\t\t\tbreak\n\t\t\tend\n\t\tend\n\tend\nelseif numGroupMembers > 5 then\n\tfor r = 1, numGroupMembers do\n\t\tlocal raidmember = 'raid' .. r\n\t\tlocal SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", raidmember)\n\t\tif UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 and (GetUnitName(raidmember) == \"" + AllyName1 + "\" or GetUnitName(raidmember) == \"" + AllyName2 + "\" or GetUnitName(raidmember) == \"" + AllyName3 + "\" or GetUnitName(raidmember) == \"" + AllyName4 + "\") then\n\t\t\tlocal hasPrescienceBuff = false\n\t\t\tfor i = 1, 25 do\n\t\t\t\tlocal name, _, _, _, _, _, source = UnitAura(raidmember, i)\n\t\t\t\tif name == \"" + Prescience_SpellName(Language) + "\" and source == 'player' then\n\t\t\t\t\thasPrescienceBuff = true\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif not hasPrescienceBuff then\n\t\t\t\tout = r\n\t\t\t\tbreak\n\t\t\tend\n\t\tend\n\tend\nend\n\nreturn out"
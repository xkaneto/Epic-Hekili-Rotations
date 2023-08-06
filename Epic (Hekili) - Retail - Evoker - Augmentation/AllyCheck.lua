local out = 0
local numGroupMembers = GetNumGroupMembers()

if UnitExists('mouseover') then
    if  UnitIsPlayer('mouseover') ~= true and IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", 'mouseover') == 1 and (GetUnitName('mouseover') == AllyName1 or GetUnitName('mouseover') == AllyName2) then
        out = 100
    end
end

if numGroupMembers > 0 and numGroupMembers < 6 then
    for p = 1, numGroupMembers do
        local partymember = 'party' .. p
        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)
        if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 and (GetUnitName(partymember) == \"" + AllyName1 + "\" or GetUnitName(partymember) == \"" + AllyName2 + "\") then
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
        if UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 and (GetUnitName(raidmember) == \"" + AllyName1 + "\" or GetUnitName(raidmember) == \"" + AllyName2 + "\") then
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

--"local out = 0\nlocal numGroupMembers = GetNumGroupMembers()\n\nif UnitExists('mouseover') then\n    if  UnitIsPlayer('mouseover') ~= true and IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", 'mouseover') and (GetUnitName('mouseover') == AllyName1 or GetUnitName('mouseover') == AllyName2) then\n        out = 100\n    end\nend\n\nif numGroupMembers < 6 then\n    for p = 1, numGroupMembers do\n        local partymember = 'party' .. p\n        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)\n        if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange and (GetUnitName(raidmember) == \"" + AllyName1 + "\" or GetUnitName(raidmember) == \"" + AllyName2 + "\") then\n            local hasPrescienceBuff = false\n            for i = 1, 25 do\n                local name, _, _, _, _, _, source = UnitAura(partymember, i)\n                if name == \"" + Prescience_SpellName(Language) + "\" and source == 'player' then\n                    hasPrescienceBuff = true\n                    break\n                end\n            end\n            if not hasPrescienceBuff then\n                out = p\n                break\n            end\n        end\n    end\nelseif numGroupMembers > 5 then\n    for r = 1, numGroupMembers do\n        local raidmember = 'raid' .. r\n        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", raidmember)\n        if UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange and (GetUnitName(raidmember) == \"" + AllyName1 + "\" or GetUnitName(raidmember) == \"" + AllyName2 + "\") then\n            local hasPrescienceBuff = false\n            for i = 1, 25 do\n                local name, _, _, _, _, _, source = UnitAura(raidmember, i)\n                if name == \"" + Prescience_SpellName(Language) + "\" and source == 'player' then\n                    hasPrescienceBuff = true\n                    break\n                end\n            end\n            if not hasPrescienceBuff then\n                out = r\n                break\n            end\n        end\n    end\nend\n\nreturn out"
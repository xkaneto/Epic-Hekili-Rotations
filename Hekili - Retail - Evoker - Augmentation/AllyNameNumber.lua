local out = 0;
local numGroupMembers = GetNumGroupMembers();
if numGroupMembers > 0 and numGroupMembers < 6 then
    for p = 1, numGroupMembers do
        local partymember = 'party' .. p
        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)
        if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then
            if GetUnitName(partymember) == \"" + AllyName1 + "\" then
                out = p
                break
            end
        end
    end
elseif numGroupMembers > 5 then
    for r = 1, numGroupMembers do
        local partymember = 'raid' .. r
        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)
        if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then
            if GetUnitName(partymember) == \"" + AllyName1 + "\" then
                out = r
                break
            end
        end
    end
end
return out

-- "local out = 0;\nlocal numGroupMembers = GetNumGroupMembers();\nif numGroupMembers > 0 and numGroupMembers < 6 then\n    for p = 1, numGroupMembers do\n        local partymember = 'party' .. p\n        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)\n        if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then\n            if GetUnitName(partymember) == \"" + AllyName1 + "\" then\n                out = p\n                break\n            end\n        end\n    end\nelseif numGroupMembers > 5 then\n    for r = 1, numGroupMembers do\n        local partymember = 'raid' .. r\n        local SpellinRange = IsSpellInRange(\"" + Prescience_SpellName(Language) + "\", partymember)\n        if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 then\n            if GetUnitName(partymember) == \"" + AllyName1 + "\" then\n                out = r\n                break\n            end\n        end\n    end\nend\nreturn out"
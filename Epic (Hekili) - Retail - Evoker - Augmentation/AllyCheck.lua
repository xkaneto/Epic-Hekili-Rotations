"local out = 0" +
"    local numGroupMembers = GetNumGroupMembers()" +
"    if UnitExists('mouseover') then" +
"        if not UnitIsEnemy('player', 'mouseover') and UnitName('mouseover') == \"" + AllyName1 + "\" then" +
"            out = 100" +
"        end" +
"    end" +
"    if numGroupMembers < 6 then" +
"        for p = 1, 4 do" +
"            local partymember = 'party' .. p" +
"            if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and UnitIsPlayer(partymember) and UnitName(partymember) == \"" + AllyName1 + "\" then" +
"                for i = 1, 25 do" +
"                    local name, _, _, _, _, _, source = UnitAura(partymember, i)" +
"                    if name == \"" + Prescience_SpellName(Language) + "\" and source ~= 'player' then" +
"                        out = p" +
"                        break" +
"                    end" +
"                end" +
"            end" +
"        end" +
"    else" +
"        for r = 1, 20 do" +
"            local raidmember = 'raid' .. r" +
"            if UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and UnitIsPlayer(raidmember) and UnitName(raidmember) == \"" + AllyName1 + "\" then" +
"                for i = 1, 25 do" +
"                    local name, _, _, _, _, _, source = UnitAura(raidmember, i)" +
"                    if name == \"" + Prescience_SpellName(Language) + "\" and source ~= 'player' then" +
"                        out = r" +
"                        break" +
"                    end" +
"                end" +
"            end" +
"        end" +
"    end" +
"    return out"
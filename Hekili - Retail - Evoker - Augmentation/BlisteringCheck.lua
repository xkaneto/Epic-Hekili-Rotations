local out = 0;
local numGroupMembers = GetNumGroupMembers();
if numGroupMembers > 0 and numGroupMembers < 6 then
    for p = 1, numGroupMembers do
        local partymember = 'party' .. p
        local SpellinRange = IsSpellInRange(\"" + BlisteringScales_SpellName(Language) + "\", partymember)
        local role = UnitGroupRolesAssigned(partymember)
        if UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 and role == \"TANK\" then
            local hasBlistering = false
            for i = 1, 40 do
                local name, _, stacks, _, _, _, _, _, _, buffid = UnitAura(partymember, i)
                if buffid == 360827 and stacks > 2 then
                    hasBlistering = true
                    break
                end
            end
            if not hasBlistering then
                out = p
                break
            end
        end
    end
elseif numGroupMembers > 5 then
    for r = 1, numGroupMembers do
        local raidmember = 'raid' .. r
        local SpellinRange = IsSpellInRange(\"" + BlisteringScales_SpellName(Language) + "\", raidmember)
        local role = UnitGroupRolesAssigned(raidmember)
        if UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 and role == \"TANK\" then
            local hasBlistering = false
            for i = 1, 40 do
                local name, _, stacks, _, _, _, _, _, _, buffid = UnitAura(raidmember, i)
                if buffid == 360827 and stacks > 2 then
                    hasBlistering = true
                    break
                end
            end
            if not hasBlistering then
                out = r
                break
            end
        end
    end
end
return out;

--"local out = 0;\nlocal numGroupMembers = GetNumGroupMembers();\nif numGroupMembers > 0 and numGroupMembers < 6 then\n\tfor p = 1, numGroupMembers do\n\t\tlocal partymember = 'party' .. p\n\t\tlocal SpellinRange = IsSpellInRange(\"" + BlisteringScales_SpellName(Language) + "\", partymember)\n\t\tlocal role = UnitGroupRolesAssigned(partymember)\n\t\tif UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and SpellinRange == 1 and role == \"TANK\" then\n\t\t\tlocal hasBlistering = false\n\t\t\tfor i = 1, 40 do\n\t\t\t\tlocal name, _, stacks, _, _, _, _, _, _, buffid = UnitAura(partymember, i)\n\t\t\t\tif buffid == 360827 and stacks > 2 then\n\t\t\t\t\thasBlistering = true\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif not hasBlistering then\n\t\t\t\tout = p\n\t\t\t\tbreak\n\t\t\tend\n\t\tend\n\tend\nelseif numGroupMembers > 5 then\n\tfor r = 1, numGroupMembers do\n\t\tlocal raidmember = 'raid' .. r\n\t\tlocal SpellinRange = IsSpellInRange(\"" + BlisteringScales_SpellName(Language) + "\", raidmember)\n\t\tlocal role = UnitGroupRolesAssigned(raidmember)\n\t\tif UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and SpellinRange == 1 and role == \"TANK\" then\n\t\t\tlocal hasBlistering = false\n\t\t\tfor i = 1, 40 do\n\t\t\t\tlocal name, _, stacks, _, _, _, _, _, _, buffid = UnitAura(raidmember, i)\n\t\t\t\tif buffid == 360827 and stacks > 2 then\n\t\t\t\t\thasBlistering = true\n\t\t\t\t\tbreak\n\t\t\t\tend\n\t\t\tend\n\t\t\tif not hasBlistering then\n\t\t\t\tout = r\n\t\t\t\tbreak\n\t\t\tend\n\t\tend\n\tend\nend\nreturn out;"
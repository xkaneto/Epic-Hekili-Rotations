"local out = 0" +
"local numGroupMembers = GetNumGroupMembers()" +
"if UnitExists('mouseover') then" +
"\tif not UnitIsEnemy('player', 'mouseover') and UnitName('mouseover') == \"" + AllyName1 + "\" or UnitName('mouseover') == \"" + AllyName2 + "\" then" +
"\t\tout = 100" +
"\tend" +
"end" +
"if numGroupMembers < 6 then" +
"\tfor p = 1, numGroupMembers do" +
"\t\tlocal partymember = 'party' .. p" +
"\t\tif UnitExists(partymember) and UnitIsDeadOrGhost(partymember) ~= true and (UnitName(partymember) == \"" + AllyName1 + "\" or UnitName(partymember) == \"" + AllyName2 + "\") then" +
"\t\t\tfor i = 1, 25 do" +
"\t\t\t\tlocal name, _, _, _, _, _, _, _, _, _, _, _, castbyplayer = UnitAura(partymember, i)" +
"\t\t\t\tif name == \"" + Prescience_SpellName(Language) + "\" and castbyplayer ~= true then" +
"\t\t\t\t\tout = p" +
"\t\t\t\tbreak" +
"\t\t\tend" +
"\t\tend" +
"\tend" +
"end" +
"else" +
"\tfor r = 1, numGroupMembers do" +
"\t\tlocal raidmember = 'raid' .. r" +
"\t\tif UnitExists(raidmember) and UnitIsDeadOrGhost(raidmember) ~= true and (UnitName(raidmember) == \"" + AllyName1 + "\" or UnitName(raidmember) == \"" + AllyName2 + "\") then" +
"\t\t\tfor i = 1, 25 do" +
"\t\t\t\tlocal name, _, _, _, _, _, _, _, _, _, _, _, castbyplayer = UnitAura(raidmember, i)" +
"\t\t\t\tif name == \"" + Prescience_SpellName(Language) + "\" and castbyplayer ~= true then" +
"\t\t\t\t\tout = r" +
"\t\t\t\t\tbreak" +
"\t\t\t\tend" +
"\t\t\tend" +
"\t\tend" +
"\tend" +
"end" +
"return out"
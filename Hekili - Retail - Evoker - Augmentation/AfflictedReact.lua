if UnitExists("mouseover") and not UnitIsPlayer("mouseover") then
    local UnitName = UnitName("mouseover")
    if UnitName == \"" + AfflictedSoul_SpellName(Language) + "\" then
        return 1
    end
    if UnitName == \"" + IncorporealBeing_SpellName(Language) + "\" then
        return 2
    end
end
return 0

-- "if UnitExists("mouseover") and not UnitIsPlayer("mouseover") then\nlocal UnitName = UnitName("mouseover")\nif UnitName == \"" + AfflictedSoul_NPCName(Language) + "\" then\n\treturn 1\nend\nif UnitName == \"" + IncorporealSoul_NPCName(Language) + "\" then\n\treturn 2\nend\nend\nreturn 0"
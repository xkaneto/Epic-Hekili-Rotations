if UnitExists("mouseover") and not UnitIsPlayer("mouseover") then
    local npcID = tonumber((UnitGUID("mouseover")):sub(-10, -7), 16)
    if npcID == 204773 then
        return 1
    end
    if npcID == 204560 then
        return 2
    end
end
return 0

-- "if UnitExists("mouseover") and not UnitIsPlayer("mouseover") then\nlocal npcID = tonumber((UnitGUID("mouseover")):sub(-10, -7), 16)\nif npcID == 204773 then\n\treturn 1\nend\nif npcID == 204560 then\n\treturn 2\nend\nend\nreturn 0"
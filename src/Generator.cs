using System;
using System.Collections.Generic;
using System.Numerics;

public class Generator
{
    #region VMFInfo

    private const string VersionInfo =
    @"versioninfo
{
    ""editorversion"" ""400""
    ""editorbuild"" ""8456""
    ""mapversion"" ""1""
    ""formatversion"" ""100""
    ""prefab"" ""0""
}";

    private const string ViewSettings =
    @"viewsettings
{
    ""bSnapToGrid"" ""1""
    ""bShowGrid"" ""1""
    ""bShowLogicalGrid"" ""0""
    ""nGridSpacing"" ""64""
    ""bShow3DGrid"" ""0""
}";

    private const string WorldSetup =
            @"""id"" ""1""
    ""mapversion"" ""797""
    ""classname"" ""worldspawn""
    ""comment"" ""Map generated with Down's VMF Filler""
    ""detailmaterial"" ""detail/detailsprites""
    ""detailvbsp"" ""detail.vbsp""
    ""maxpropscreenwidth"" ""-1""
    ""skyname"" ""sky_cs15_daylight02_hdr""";

    private const string DispInfo =
    @"dispinfo
{
	""power"" ""3""
	""startposition"" ""[-5120 -1024 192]""
	""flags"" ""0""
	""elevation"" ""0""
	""subdiv"" ""0""
	normals
	{
		""row0"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row1"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row2"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row3"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row4"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row5"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row6"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row7"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row8"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
	}
	distances
	{
		""row0"" ""0 0 0 0 0 0 0 0 0""
		""row1"" ""0 0 0 0 0 0 0 0 0""
		""row2"" ""0 0 0 0 0 0 0 0 0""
		""row3"" ""0 0 0 0 0 0 0 0 0""
		""row4"" ""0 0 0 0 0 0 0 0 0""
		""row5"" ""0 0 0 0 0 0 0 0 0""
		""row6"" ""0 0 0 0 0 0 0 0 0""
		""row7"" ""0 0 0 0 0 0 0 0 0""
		""row8"" ""0 0 0 0 0 0 0 0 0""
	}
	offsets
	{
		""row0"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row1"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row2"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row3"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row4"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row5"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row6"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row7"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
		""row8"" ""0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0""
	}
	offset_normals
	{
		""row0"" ""0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1""
		""row1"" ""0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1""
		""row2"" ""0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1""
		""row3"" ""0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1""
		""row4"" ""0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1""
		""row5"" ""0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1""
		""row6"" ""0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1""
		""row7"" ""0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1""
		""row8"" ""0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1 0 0 1""
	}
	alphas
	{
		""row0"" ""0 0 0 0 0 0 0 0 0""
		""row1"" ""0 0 0 0 0 0 0 0 0""
		""row2"" ""0 0 0 0 0 0 0 0 0""
		""row3"" ""0 0 0 0 0 0 0 0 0""
		""row4"" ""0 0 0 0 0 0 0 0 0""
		""row5"" ""0 0 0 0 0 0 0 0 0""
		""row6"" ""0 0 0 0 0 0 0 0 0""
		""row7"" ""0 0 0 0 0 0 0 0 0""
		""row8"" ""0 0 0 0 0 0 0 0 0""
	}
	triangle_tags
	{
		""row0"" ""9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9""
		""row1"" ""9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9""
		""row2"" ""9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9""
		""row3"" ""9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9""
		""row4"" ""9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9""
		""row5"" ""9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9""
		""row6"" ""9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9""
		""row7"" ""9 9 9 9 9 9 9 9 9 9 9 9 9 9 9 9""
	}
	allowed_verts
	{
		""10"" ""-1 -1 -1 -1 -1 -1 -1 -1 -1 -1""
	}
}";

    #endregion

    List<string> solids = new List<string>();
    List<string> objects = new List<string>();
    public int iSolids = 2;

    public string SolidInfo(List<string> sides)
    {
        string s = "";
        s += @"""id"" " + "\"" + iSolids + "\"" + Environment.NewLine;

        foreach (string side in sides)
        {
            s += side;
        }

        s += "editor" + Environment.NewLine;
        s += "{" + Environment.NewLine;
        s += "\"color\" " + "\"0 150 225\"" + Environment.NewLine;
        s += "\"visgroupshown\" " + "\"1\"" + Environment.NewLine;
        s += "\"visgroupautoshown\" " + "\"1\"" + Environment.NewLine;
        s += "}" + Environment.NewLine;

        return s;
    }

    public void MakeSolid(string solidInfo)
    {
        string s = "";
        s += "solid" + Environment.NewLine;
        s += "{" + Environment.NewLine;
        s += "\"id\" " + "\"" + iSolids + "\"" + Environment.NewLine;
        s += solidInfo + Environment.NewLine;
        s += "}" + Environment.NewLine;

        solids.Add(s);
        iSolids++;
    }

    public string MakeSide(int id, Vector3 pos1, Vector3 pos2, Vector3 pos3, bool disp)
    {
        string s = "";
        s += "side" + Environment.NewLine;
        s += "{" + Environment.NewLine;

        s += "\"id\" " + "\"" + id + "\"" + Environment.NewLine;
        s += "\"plane\" " + "\"(" + pos1.X + " " + pos1.Y + " " + pos1.Z + ") " + "(" + pos2.X + " " + pos2.Y + " " + pos2.Z + ") " + "(" + pos3.X + " " + pos3.Y + " " + pos3.Z + ")\"" + Environment.NewLine;
        s += "\"material\" " + "\"dev/dev_measuregeneric01b\"" + Environment.NewLine;
        s += "\"uaxis\" " + "\"[1 0 0 0] 0.25\"" + Environment.NewLine;
        s += "\"vaxis\" " + "\"[0 -1 0 0] 0.25\"" + Environment.NewLine;
        s += "\"rotation\" " + "\"0\"" + Environment.NewLine;
        s += "\"lightmapscale\" " + "\"16\"" + Environment.NewLine;
        s += "\"smoothing_groups\" " + "\"0\"" + Environment.NewLine;
        if (disp)
        {
            s+= DispInfo + Environment.NewLine;
        }

        s += "}" + Environment.NewLine;

        return s;
    }

    public string MakeCube(Vector3 pos, Vector3 size)
    {
        string s = "";

        size = size * 0.5f;

        // top
        s += MakeSide(1, new Vector3(-size.Y, size.X, size.Z) + pos, new Vector3(size.Y, size.X, size.Z) + pos, new Vector3(size.Y, -size.X, size.Z) + pos, false);
        
        // bottom
        s += MakeSide(2, new Vector3(-size.Y, -size.X, -size.Z) + pos, new Vector3(size.Y, -size.X, -size.Z) + pos, new Vector3(size.Y, size.X, -size.Z) + pos, false);
        
        // left
        s += MakeSide(3, new Vector3(-size.Y, size.X, size.Z) + pos, new Vector3(-size.Y, -size.X, size.Z) + pos, new Vector3(-size.Y, -size.X, -size.Z) + pos, false);
        
        // right
        s += MakeSide(4, new Vector3(size.Y, size.X, -size.Z) + pos, new Vector3(size.Y, -size.X, -size.Z) + pos, new Vector3(size.Y, -size.X, size.Z) + pos, false);
        
        // forward
        s += MakeSide(5, new Vector3(size.Y, size.X, size.Z) + pos, new Vector3(-size.Y, size.X, size.Z) + pos, new Vector3(-size.Y, size.X, -size.Z) + pos, false);
        
        // back
        s += MakeSide(6, new Vector3(size.Y, -size.X, -size.Z) + pos, new Vector3(-size.Y, -size.X, -size.Z) + pos, new Vector3(-size.Y, -size.X, size.Z) + pos, false);

        return s;
    }

    public string MakeDisplacement(Vector3 pos, Vector3 size)
    {
        string s = "";

        size = size * 0.5f;

        // top
        s += MakeSide(1, new Vector3(-size.Y, size.X, size.Z) + pos, new Vector3(size.Y, size.X, size.Z) + pos, new Vector3(size.Y, -size.X, size.Z) + pos, true);
        
        // bottom
        s += MakeSide(2, new Vector3(-size.Y, -size.X, -size.Z) + pos, new Vector3(size.Y, -size.X, -size.Z) + pos, new Vector3(size.Y, size.X, -size.Z) + pos, false);
        
        // left
        s += MakeSide(3, new Vector3(-size.Y, size.X, size.Z) + pos, new Vector3(-size.Y, -size.X, size.Z) + pos, new Vector3(-size.Y, -size.X, -size.Z) + pos, false);
        
        // right
        s += MakeSide(4, new Vector3(size.Y, size.X, -size.Z) + pos, new Vector3(size.Y, -size.X, -size.Z) + pos, new Vector3(size.Y, -size.X, size.Z) + pos, false);
        
        // forward
        s += MakeSide(5, new Vector3(size.Y, size.X, size.Z) + pos, new Vector3(-size.Y, size.X, size.Z) + pos, new Vector3(-size.Y, size.X, -size.Z) + pos, false);
        
        // back
        s += MakeSide(6, new Vector3(size.Y, -size.X, -size.Z) + pos, new Vector3(-size.Y, -size.X, -size.Z) + pos, new Vector3(-size.Y, -size.X, size.Z) + pos, false);

        return s;
    }

    public string Generate()
    {
        string s = "";
        
        s += VersionInfo + Environment.NewLine;
        s += ViewSettings + Environment.NewLine;

        s += "world" + Environment.NewLine;
        s += "{" + Environment.NewLine;
        s += WorldSetup + Environment.NewLine;

        int newStrLength = 0;
        foreach (string solid in solids)
        {
            newStrLength += solid.Length + Environment.NewLine.Length;
        }

        s += string.Create(newStrLength, solids, (span, state) =>
        {
            int current = 0;
            foreach (var str in state)
            {
                var s = span.Slice(current);
			
				str.AsSpan().CopyTo(s);

                current += str.Length;
            }
        });
        
        s += "}" + Environment.NewLine;

        return s;
    }
}
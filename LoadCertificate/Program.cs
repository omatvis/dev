using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Update;

namespace LoadCertificate;

internal static class Program
{
    static void Main(string[] args)
    {
        ScCertdist? scCertdistRow = null;
        ScCertdet? scCertdetRow = null;
        ScVatdist? scVatdistRow = null;
        ScCertitem? scCertitemRow = null;

        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "analyse.xml");
        using (XmlReader xmlReader = XmlReader.Create(filePath))
        {
            string elementName = string.Empty;
            while (xmlReader.Read())
            {
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    elementName = xmlReader.Name;
                    if (elementName == "sc_certdistRow")
                    {
                        scCertdistRow = new ScCertdist();
                    }
                    else if (elementName == "sc_certdetRow")
                    {
                        scCertdetRow = new ScCertdet();
                    }
                    else if (elementName == "sc_vatdistRow")
                    {
                        scVatdistRow = new ScVatdist();
                    }
                    else if (elementName == "sc_certitemRow")
                    {
                        scCertitemRow = new ScCertitem();
                    }
                }
                else if (xmlReader.NodeType == XmlNodeType.Text)
                {
                    if (scCertdistRow is not null)
                    {
                        SetPropertyByFieldName(elementName, scCertdistRow, xmlReader.Value);
                    }
                    else if (scCertdetRow is not null)
                    {
                        SetPropertyByFieldName(elementName, scCertdetRow, xmlReader.Value);
                    }
                    else if (scVatdistRow is not null)
                    {
                        SetPropertyByFieldName(elementName, scVatdistRow, xmlReader.Value);
                    }
                    else if (scCertitemRow is not null)
                    {
                        SetPropertyByFieldName(elementName, scCertitemRow, xmlReader.Value);
                    }
                }
                else if (xmlReader.NodeType == XmlNodeType.EndElement)
                {
                    if (xmlReader.Name == "sc_certdistRow")
                    {
                        AddScCertdistRow(scCertdistRow);
                        scCertdistRow = null;
                    }
                    else if (xmlReader.Name == "sc_certdetRow")
                    {
                        AddScCertdetRow(scCertdetRow);
                        scCertdetRow = null;
                    }
                    else if (xmlReader.Name == "sc_vatdistRow")
                    {
                        AddScVatdistRow(scVatdistRow);
                        scVatdistRow = null;
                    }
                    else if (xmlReader.Name == "sc_certitemRow")
                    {
                        AddScCertitemRow(scCertitemRow);
                        scCertitemRow = null;
                    }
                    elementName = string.Empty;
                }
            }
        }
    }

    public static int AddScCertdistRow(ScCertdist? scCertdistRow)
    {
        if (scCertdistRow is null)
        {
            return -1;
        }
        using (FinanceContext db = new())
        {
            EntityEntry<ScCertdist> entityEntry = db.ScCertdists.Add(scCertdistRow);
            return db.SaveChanges();
        }
    }

    public static int AddScCertdetRow(ScCertdet? scCertdetRow)
    {
        if (scCertdetRow is null)
        {
            return -1;
        }
        using (FinanceContext db = new())
        {
            EntityEntry<ScCertdet> entityEntry = db.ScCertdets.Add(scCertdetRow);
            return db.SaveChanges();
        }
    }

    public static int AddScVatdistRow(ScVatdist? scVatdistRow)
    {
        if (scVatdistRow is null)
        {
            return -1;
        }
        using (FinanceContext db = new())
        {
            EntityEntry<ScVatdist> entityEntry = db.ScVatdists.Add(scVatdistRow);
            return db.SaveChanges();
        }
    }

    public static int AddScCertitemRow(ScCertitem? scCertitemRow)
    {
        if (scCertitemRow is null)
        {
            return -1;
        }
        using (FinanceContext db = new())
        {
            EntityEntry<ScCertitem> entityEntry = db.ScCertitems.Add(scCertitemRow);
            return db.SaveChanges();
        }
    }

    public static bool SetPropertyByFieldName(string fieldName, object source, string value)
    {
        var sourceType = source.GetType();
        if (sourceType is not null)
        {
            foreach (var property in sourceType.GetProperties())
            {
                var propertyAttributes = Attribute.GetCustomAttributes(property);
                foreach (var attribute in propertyAttributes)
                {
                    if (attribute is ColumnAttribute columnAttribute)
                    {
                        if (columnAttribute.Name == fieldName)
                        {
                            var type =
                                Nullable.GetUnderlyingType(property.PropertyType)
                                ?? property.PropertyType;

                            if (property.PropertyType.IsEnum)
                            {
                                property.SetValue(
                                    source,
                                    Enum.Parse(property.PropertyType, value.ToString()!)
                                );
                            }
                            else if (type.ToString() == "System.DateOnly")
                            {
                                var dateValue = DateOnly.Parse(value);
                                property.SetValue(source, dateValue, null);
                            }
                            else
                            {
                                var safeValue =
                                    (value == null) ? null : Convert.ChangeType(value, type);
                                property.SetValue(source, safeValue, null);
                            }
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}

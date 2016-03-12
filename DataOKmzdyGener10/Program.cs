using System;
using OKmzdy.SqlSchemaInfo;
using System.Collections.Generic;
using OKmzdy.OKmzdySchemaInfo;

namespace DataOKmzdyGener10
{
	class MainClass
	{
		private static string ExecutableAppFolder()
		{
			string[] args = Environment.GetCommandLineArgs();

			string appExecutableFileNm = args[0];

			return System.IO.Path.GetDirectoryName(appExecutableFileNm);
		}

		public static void Main (string[] args)
		{
			BaseSchemaManager m_SchemaManager;

			string sourceOwnerName = "oksystem";
			string sourceUsersName = "okmzdy";

			m_SchemaManager = new OKmzdySchemaManager(sourceOwnerName, sourceUsersName);

			IList<string> filterInfo = new string[] {
				"PRAC",
				"ADRESA",
				"BANK_SPOJ",
				"DAN",
				"SRAZKA",
				"UVAZEK",
				"MZDA",
				"NEPRIT",
				"OSDATA",
				"HLASENI_ZP",
				"POJISTITEL",
				"PPOMER",
				"PPOMER_DOV_ROK",
				"PPOMER_MES",
				"PPOMER_DOV",
				"PPOMER_OZP",
				"PPOMER_SUM",
				"PRAC_NEPRIT",
				"PPOMER_PRAXE",
				"PPOMER_SLUZBA",
				"PRAC_VZDELAVANI",
				"PRIJMY",
				"PRIJMY_MES",
				"PRIJMY_SSP",
				"PROHLASENI",
				"RODINA"
			};

			IList<TableDefInfo> copyInfo = m_SchemaManager.CreateSubsetTableList(filterInfo);

			string appExecutableFolder = ExecutableAppFolder();

			string contextFileName = "OKmzdyContextSource.cs";
			string contextFilePath = System.IO.Path.Combine(appExecutableFolder, contextFileName);

			string configsFileName = "OKmzdyConfigsSource.cs";
			string configsFilePath = System.IO.Path.Combine(appExecutableFolder, configsFileName);
			string sourcesFoldName = "CompanyEntity";
			string sourcesFoldPath = System.IO.Path.Combine(appExecutableFolder, sourcesFoldName);

			string contextPackName = "Company";
			DataSourceGenerator.CreateContextClassFile(m_SchemaManager, contextPackName, copyInfo, contextFilePath);
			DataSourceGenerator.CreateConfigsClassFile(m_SchemaManager, contextPackName, copyInfo, configsFilePath);
			DataSourceGenerator.CreateEntityClassFiles(m_SchemaManager, contextPackName, copyInfo, sourcesFoldPath);
		}
	}
}

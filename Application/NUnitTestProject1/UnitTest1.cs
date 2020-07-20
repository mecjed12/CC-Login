using ApplicationData.model;
using ApplicationData.repo;
using ApplicationLogic;
using NUnit.Framework;
using System;

namespace NUnitTestProject1
{
	public class Tests
	{
		ApplicationLogicController controller;
		CourseCategoryRepository repo;

		
		public Tests()
		{
			controller = new ApplicationLogicController(new ApplicationData.DcvEntities());
			repo = (CourseCategoryRepository)controller.GetRepository(new CourseCategory());
		}

		[Test]
		public void Test1()
		{
			Assert.IsNotNull(repo.GetOne("Coding Campus"));
			Console.WriteLine("Coding Campus");
			Assert.IsNotNull(repo.GetOne("CodingCampus"));
			Console.WriteLine("CodingCampus");
		}
	}
}
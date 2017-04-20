using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MacForms
{
	public class PeopleInSpaceResponse
	{
		public string Message { get; set; }
		public PersonInSpace[] People { get; set; }
		public int Number { get; set; }
	}

	public class IssPositionResponse
	{
		public string Message { get; set; }
		public long Timestamp { get; set; }

		[JsonProperty("iss_position")]
		public IssPosition IssPosition { get; set; }

	}

	//{"iss_position": {"latitude": "-8.7373", "longitude": "-85.5523"}, "message": "success", "timestamp": 1492693292}

	public class IssPosition
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }
	}

	public class PersonInSpace
	{
		public string Name { get; set; }
		public string Craft { get; set; }
	}
}

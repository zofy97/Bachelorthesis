#pragma warning disable 612,618
#pragma warning disable 0114
#pragma warning disable 0108

using System;
using System.Collections.Generic;
using GameSparks.Core;
using GameSparks.Api.Requests;
using GameSparks.Api.Responses;

//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!
//THIS FILE IS AUTO GENERATED, DO NOT MODIFY!!

namespace GameSparks.Api.Requests{
		public class LogEventRequest_HIGH_SCORE : GSTypedRequest<LogEventRequest_HIGH_SCORE, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_HIGH_SCORE() : base("LogEventRequest"){
			request.AddString("eventKey", "HIGH_SCORE");
		}
		public LogEventRequest_HIGH_SCORE Set_SCORE( long value )
		{
			request.AddNumber("SCORE", value);
			return this;
		}			
		
		public LogEventRequest_HIGH_SCORE Set_DAY( string value )
		{
			request.AddString("DAY", value);
			return this;
		}
	}
	
	public class LogChallengeEventRequest_HIGH_SCORE : GSTypedRequest<LogChallengeEventRequest_HIGH_SCORE, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_HIGH_SCORE() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "HIGH_SCORE");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_HIGH_SCORE SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_HIGH_SCORE Set_SCORE( long value )
		{
			request.AddNumber("SCORE", value);
			return this;
		}			
		public LogChallengeEventRequest_HIGH_SCORE Set_DAY( string value )
		{
			request.AddString("DAY", value);
			return this;
		}
	}
	
	public class LogEventRequest_LOAD_PLAYER : GSTypedRequest<LogEventRequest_LOAD_PLAYER, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_LOAD_PLAYER() : base("LogEventRequest"){
			request.AddString("eventKey", "LOAD_PLAYER");
		}
	}
	
	public class LogChallengeEventRequest_LOAD_PLAYER : GSTypedRequest<LogChallengeEventRequest_LOAD_PLAYER, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_LOAD_PLAYER() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "LOAD_PLAYER");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_LOAD_PLAYER SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
	}
	
	public class LogEventRequest_SAVE_PLAYER : GSTypedRequest<LogEventRequest_SAVE_PLAYER, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_SAVE_PLAYER() : base("LogEventRequest"){
			request.AddString("eventKey", "SAVE_PLAYER");
		}
		public LogEventRequest_SAVE_PLAYER Set_COINS( long value )
		{
			request.AddNumber("COINS", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_SAVE_PLAYER : GSTypedRequest<LogChallengeEventRequest_SAVE_PLAYER, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_SAVE_PLAYER() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "SAVE_PLAYER");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_SAVE_PLAYER SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_SAVE_PLAYER Set_COINS( long value )
		{
			request.AddNumber("COINS", value);
			return this;
		}			
	}
	
	public class LogEventRequest_SUBMIT_SCORE : GSTypedRequest<LogEventRequest_SUBMIT_SCORE, LogEventResponse>
	{
	
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogEventResponse (response);
		}
		
		public LogEventRequest_SUBMIT_SCORE() : base("LogEventRequest"){
			request.AddString("eventKey", "SUBMIT_SCORE");
		}
		public LogEventRequest_SUBMIT_SCORE Set_SCORE( long value )
		{
			request.AddNumber("SCORE", value);
			return this;
		}			
	}
	
	public class LogChallengeEventRequest_SUBMIT_SCORE : GSTypedRequest<LogChallengeEventRequest_SUBMIT_SCORE, LogChallengeEventResponse>
	{
		public LogChallengeEventRequest_SUBMIT_SCORE() : base("LogChallengeEventRequest"){
			request.AddString("eventKey", "SUBMIT_SCORE");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LogChallengeEventResponse (response);
		}
		
		/// <summary>
		/// The challenge ID instance to target
		/// </summary>
		public LogChallengeEventRequest_SUBMIT_SCORE SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		public LogChallengeEventRequest_SUBMIT_SCORE Set_SCORE( long value )
		{
			request.AddNumber("SCORE", value);
			return this;
		}			
	}
	
}
	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_SCORE_LEADERBOARD : GSTypedRequest<LeaderboardDataRequest_SCORE_LEADERBOARD,LeaderboardDataResponse_SCORE_LEADERBOARD>
	{
		public LeaderboardDataRequest_SCORE_LEADERBOARD() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "SCORE_LEADERBOARD");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_SCORE_LEADERBOARD (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_SCORE_LEADERBOARD SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_SCORE_LEADERBOARD SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_SCORE_LEADERBOARD SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_SCORE_LEADERBOARD SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_SCORE_LEADERBOARD SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_SCORE_LEADERBOARD SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_SCORE_LEADERBOARD SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_SCORE_LEADERBOARD SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_SCORE_LEADERBOARD SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_SCORE_LEADERBOARD : GSTypedRequest<AroundMeLeaderboardRequest_SCORE_LEADERBOARD,AroundMeLeaderboardResponse_SCORE_LEADERBOARD>
	{
		public AroundMeLeaderboardRequest_SCORE_LEADERBOARD() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "SCORE_LEADERBOARD");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_SCORE_LEADERBOARD (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_SCORE_LEADERBOARD SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_SCORE_LEADERBOARD SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_SCORE_LEADERBOARD SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_SCORE_LEADERBOARD SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_SCORE_LEADERBOARD SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_SCORE_LEADERBOARD SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_SCORE_LEADERBOARD SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_SCORE_LEADERBOARD : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_SCORE_LEADERBOARD(GSData data) : base(data){}
		public long? SCORE{
			get{return response.GetNumber("SCORE");}
		}
	}
	
	public class LeaderboardDataResponse_SCORE_LEADERBOARD : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_SCORE_LEADERBOARD(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD> Data_SCORE_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_SCORE_LEADERBOARD(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD> First_SCORE_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_SCORE_LEADERBOARD(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD> Last_SCORE_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_SCORE_LEADERBOARD(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_SCORE_LEADERBOARD : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_SCORE_LEADERBOARD(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD> Data_SCORE_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_SCORE_LEADERBOARD(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD> First_SCORE_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_SCORE_LEADERBOARD(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD> Last_SCORE_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_SCORE_LEADERBOARD>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_SCORE_LEADERBOARD(data);});}
		}
	}
}	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_HSL30D : GSTypedRequest<LeaderboardDataRequest_HSL30D,LeaderboardDataResponse_HSL30D>
	{
		public LeaderboardDataRequest_HSL30D() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "HSL30D");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_HSL30D (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_HSL30D SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_HSL30D SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_HSL30D SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_HSL30D SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_HSL30D SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_HSL30D SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_HSL30D SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_HSL30D SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_HSL30D SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_HSL30D : GSTypedRequest<AroundMeLeaderboardRequest_HSL30D,AroundMeLeaderboardResponse_HSL30D>
	{
		public AroundMeLeaderboardRequest_HSL30D() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "HSL30D");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_HSL30D (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_HSL30D SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_HSL30D SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_HSL30D SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_HSL30D SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_HSL30D SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_HSL30D SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_HSL30D SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_HSL30D : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_HSL30D(GSData data) : base(data){}
		public long? SCORE{
			get{return response.GetNumber("SCORE");}
		}
		public string MAX_DAY{
			get{return response.GetString("MAX-DAY");}
		}
	}
	
	public class LeaderboardDataResponse_HSL30D : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_HSL30D(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_HSL30D> Data_HSL30D{
			get{return new GSEnumerable<_LeaderboardEntry_HSL30D>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_HSL30D(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HSL30D> First_HSL30D{
			get{return new GSEnumerable<_LeaderboardEntry_HSL30D>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_HSL30D(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HSL30D> Last_HSL30D{
			get{return new GSEnumerable<_LeaderboardEntry_HSL30D>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_HSL30D(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_HSL30D : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_HSL30D(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_HSL30D> Data_HSL30D{
			get{return new GSEnumerable<_LeaderboardEntry_HSL30D>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_HSL30D(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HSL30D> First_HSL30D{
			get{return new GSEnumerable<_LeaderboardEntry_HSL30D>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_HSL30D(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_HSL30D> Last_HSL30D{
			get{return new GSEnumerable<_LeaderboardEntry_HSL30D>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_HSL30D(data);});}
		}
	}
}	
	
	
namespace GameSparks.Api.Requests{
	
	public class LeaderboardDataRequest_LEADERBOARD : GSTypedRequest<LeaderboardDataRequest_LEADERBOARD,LeaderboardDataResponse_LEADERBOARD>
	{
		public LeaderboardDataRequest_LEADERBOARD() : base("LeaderboardDataRequest"){
			request.AddString("leaderboardShortCode", "LEADERBOARD");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new LeaderboardDataResponse_LEADERBOARD (response);
		}		
		
		/// <summary>
		/// The challenge instance to get the leaderboard data for
		/// </summary>
		public LeaderboardDataRequest_LEADERBOARD SetChallengeInstanceId( String challengeInstanceId )
		{
			request.AddString("challengeInstanceId", challengeInstanceId);
			return this;
		}
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public LeaderboardDataRequest_LEADERBOARD SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_LEADERBOARD SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public LeaderboardDataRequest_LEADERBOARD SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public LeaderboardDataRequest_LEADERBOARD SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// The offset into the set of leaderboards returned
		/// </summary>
		public LeaderboardDataRequest_LEADERBOARD SetOffset( long offset )
		{
			request.AddNumber("offset", offset);
			return this;
		}
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public LeaderboardDataRequest_LEADERBOARD SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public LeaderboardDataRequest_LEADERBOARD SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public LeaderboardDataRequest_LEADERBOARD SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
		
	}

	public class AroundMeLeaderboardRequest_LEADERBOARD : GSTypedRequest<AroundMeLeaderboardRequest_LEADERBOARD,AroundMeLeaderboardResponse_LEADERBOARD>
	{
		public AroundMeLeaderboardRequest_LEADERBOARD() : base("AroundMeLeaderboardRequest"){
			request.AddString("leaderboardShortCode", "LEADERBOARD");
		}
		
		protected override GSTypedResponse BuildResponse (GSObject response){
			return new AroundMeLeaderboardResponse_LEADERBOARD (response);
		}		
		
		/// <summary>
		/// The number of items to return in a page (default=50)
		/// </summary>
		public AroundMeLeaderboardRequest_LEADERBOARD SetEntryCount( long entryCount )
		{
			request.AddNumber("entryCount", entryCount);
			return this;
		}
		/// <summary>
		/// A friend id or an array of friend ids to use instead of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_LEADERBOARD SetFriendIds( List<string> friendIds )
		{
			request.AddStringList("friendIds", friendIds);
			return this;
		}
		/// <summary>
		/// Number of entries to include from head of the list
		/// </summary>
		public AroundMeLeaderboardRequest_LEADERBOARD SetIncludeFirst( long includeFirst )
		{
			request.AddNumber("includeFirst", includeFirst);
			return this;
		}
		/// <summary>
		/// Number of entries to include from tail of the list
		/// </summary>
		public AroundMeLeaderboardRequest_LEADERBOARD SetIncludeLast( long includeLast )
		{
			request.AddNumber("includeLast", includeLast);
			return this;
		}
		
		/// <summary>
		/// If True returns a leaderboard of the player's social friends
		/// </summary>
		public AroundMeLeaderboardRequest_LEADERBOARD SetSocial( bool social )
		{
			request.AddBoolean("social", social);
			return this;
		}
		/// <summary>
		/// The IDs of the teams you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_LEADERBOARD SetTeamIds( List<string> teamIds )
		{
			request.AddStringList("teamIds", teamIds);
			return this;
		}
		/// <summary>
		/// The type of team you are interested in
		/// </summary>
		public AroundMeLeaderboardRequest_LEADERBOARD SetTeamTypes( List<string> teamTypes )
		{
			request.AddStringList("teamTypes", teamTypes);
			return this;
		}
	}
}

namespace GameSparks.Api.Responses{
	
	public class _LeaderboardEntry_LEADERBOARD : LeaderboardDataResponse._LeaderboardData{
		public _LeaderboardEntry_LEADERBOARD(GSData data) : base(data){}
	}
	
	public class LeaderboardDataResponse_LEADERBOARD : LeaderboardDataResponse
	{
		public LeaderboardDataResponse_LEADERBOARD(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_LEADERBOARD> Data_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_LEADERBOARD>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_LEADERBOARD(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_LEADERBOARD> First_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_LEADERBOARD>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_LEADERBOARD(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_LEADERBOARD> Last_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_LEADERBOARD>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_LEADERBOARD(data);});}
		}
	}
	
	public class AroundMeLeaderboardResponse_LEADERBOARD : AroundMeLeaderboardResponse
	{
		public AroundMeLeaderboardResponse_LEADERBOARD(GSData data) : base(data){}
		
		public GSEnumerable<_LeaderboardEntry_LEADERBOARD> Data_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_LEADERBOARD>(response.GetObjectList("data"), (data) => { return new _LeaderboardEntry_LEADERBOARD(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_LEADERBOARD> First_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_LEADERBOARD>(response.GetObjectList("first"), (data) => { return new _LeaderboardEntry_LEADERBOARD(data);});}
		}
		
		public GSEnumerable<_LeaderboardEntry_LEADERBOARD> Last_LEADERBOARD{
			get{return new GSEnumerable<_LeaderboardEntry_LEADERBOARD>(response.GetObjectList("last"), (data) => { return new _LeaderboardEntry_LEADERBOARD(data);});}
		}
	}
}	

namespace GameSparks.Api.Messages {


}

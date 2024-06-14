using System.Data.SqlClient;
using FestaECia.Models;
using FestaECia.Models.Enums;

namespace FestaECia.Repository;

public class PartyRepository : IRepository<Party>
{
	private readonly Database _database;

	public PartyRepository()
	{
		_database = new Database();
	}

	public IEnumerable<Party> GetAll()
	{
		var parties = new List<Party>();

		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand("SELECT * FROM tb_party", connection);

			using (var reader = command.ExecuteReader())
			{
				while (reader.Read())
				{
					parties.Add(RenderParty(reader));
				}
			}
		}

		return parties;
	}

	public Party GetById(int id)
	{
		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand("SELECT * FROM Party WHERE Id = @Id", connection);
			command.Parameters.AddWithValue("@Id", id);

			using (var reader = command.ExecuteReader())
			{
				if (reader.Read())
				{
					return RenderParty(reader);
				}
			}
		}

		return null;
	}

	public void Insert(Party party)
	{
		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand("INSERT INTO tb_party (Id, Date, NumberOfGuests, Space, Type, Price) VALUES (@Id, @Date, @NumberOfGuests, @Space, @Type, @Price)", connection);
			command.Parameters.AddWithValue("@Id", party.Id);
			command.Parameters.AddWithValue("@Date", party.Date);
			command.Parameters.AddWithValue("@NumberOfGuests", party.NumberOfGuests);
			command.Parameters.AddWithValue("@Space", party.Space.Name);
			command.Parameters.AddWithValue("@Type", party.Type);
			command.Parameters.AddWithValue("@Price", party.Price);

			command.ExecuteNonQuery();
		}
	}

	public void Update(Party party)
	{
		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand("UPDATE Party SET Id = @Id, Date = @Location, NumberOfGuests = @NumberOfGuests, Space = @Space, Type = @Type, Price = @Price WHERE Id = @Id", connection);
			command.Parameters.AddWithValue("@Id", party.Id);
			command.Parameters.AddWithValue("@Date", party.Date);
			command.Parameters.AddWithValue("@NumberOfGuests", party.NumberOfGuests);
			command.Parameters.AddWithValue("@Space", party.Space.Name);
			command.Parameters.AddWithValue("@Type", party.Type);
			command.Parameters.AddWithValue("@Price", party.Price);

			command.ExecuteNonQuery();
		}
	}

	public void Delete(int id)
	{
		using (var connection = _database.GetConnection())
		{
			connection.Open();
			var command = new SqlCommand("DELETE FROM Party WHERE Id = @Id", connection);
			command.Parameters.AddWithValue("@Id", id);

			command.ExecuteNonQuery();
		}
	}

	private Party RenderParty(SqlDataReader reader)
	{
		var partyType = (PartyType)reader["type"];

		int id = (int)reader["id"];
		DateTime date = (DateTime)reader["date"];
		int numberOfGuests = (int)reader["number_of_people"];
		Space space = (Space)reader["space_name"];
		double price = (double)reader["Price"];
		
		Party party;

		switch (partyType)
		{
			case PartyType.Birthday:
				party = new Birthday(id, date, numberOfGuests, space, partyType, price);
				break;
			case PartyType.Corporate:
				party = new Corporate(id, date, numberOfGuests, space, partyType, price);
				break;
			case PartyType.Free:
				party = new Free(id, date, numberOfGuests, space, partyType, price);
				break;
			case PartyType.Graduation:
				party = new Graduation(id, date, numberOfGuests, space, partyType, price);
				break;
			case PartyType.Wedding:
				party = new Wedding(id, date, numberOfGuests, space, partyType, price);
				break;
			default:
				throw new InvalidOperationException("Unknown party type");
				break;
		}
		return party;
	}

}
using System;

namespace PArticulo{

	public interface IEntityDao <TEntity>{

		TEntity Load (object id);
	}
}


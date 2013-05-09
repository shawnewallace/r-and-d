using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BranchModel.Lib
{
	public class CodeBranch
	{
		public int Id { get; set; }
		public int Name { get; set; }

		public virtual CodeBranch Trunk { get; set; }
		public virtual List<CodeBranch> Leafs { get; set; }
	}
}

using System;

namespace DeepCopyVsShallowCopy
{
    class Program
    {
        static void Main(string[] args)
        {
			//Copy
			Copy obj = new Copy();
			Copy objClone = obj;
			obj.I = 70;  
			obj.K = new ReferenceType { RFT = 80 };

			objClone.I = 100;
			objClone.K = new ReferenceType { RFT = 800 };

			Console.WriteLine("Copy");
			Console.WriteLine($"objvalue: {obj.I}-{obj.K.RFT}  Clone value: {objClone.I}-{objClone.K.RFT}");

			//ShallowCopy
			ShallowCopy objShallowCopy = new ShallowCopy();

			objShallowCopy.I = 70;          
			objShallowCopy.K = new ReferenceType { RFT = 80 } ;
			ShallowCopy objShallowCopyClone = (ShallowCopy)objShallowCopy.Clone();
			objShallowCopyClone.I = 100;
			objShallowCopyClone.K.RFT =  800;
			Console.WriteLine("---------------------------------");
			Console.WriteLine("Shallow Copy");
			Console.WriteLine($"value: {objShallowCopy.I}-{objShallowCopy.K.RFT}  Clone value: {objShallowCopyClone.I}-{objShallowCopyClone.K.RFT}");

			//DeepCopy
			DeepCopy objDeepCopy = new DeepCopy();

			objDeepCopy.I = 70;          
			objDeepCopy.K = new ReferenceType { RFT = 80 };
			DeepCopy objDeepCopyClone = (DeepCopy)objDeepCopy.Clone();
			objDeepCopyClone.I = 100;
			objDeepCopyClone.K.RFT = 800;
			Console.WriteLine("---------------------------------");
			Console.WriteLine("Deep Copy");
			Console.WriteLine($"value: {objDeepCopy.I}-{objDeepCopy.K.RFT}  Clone value: {objDeepCopyClone.I}-{objDeepCopyClone.K.RFT}");

		}
	}
	class ReferenceType
	{
		public int RFT { get; set; }
	}

	class Copy
	{
		public int I { get; set; }
		public ReferenceType K { get; set; }
	}

	class ShallowCopy
	{
		public int I { get; set; }
		public ReferenceType K { get; set; }
		public object Clone()
		{
			return this.MemberwiseClone();
		}
	}

	class DeepCopy
	{
		public int I { get; set; }
		public ReferenceType K { get; set; }

		public object Clone()
		{
			DeepCopy DC=  (DeepCopy)this.MemberwiseClone();
			ReferenceType rf = new ReferenceType();
			DC.K = rf;
			return DC;
		}
	}




}

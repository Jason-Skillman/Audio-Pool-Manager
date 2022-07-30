namespace AudioPool.Pooling {
	
	public interface IPool<T> {
		T Request();
		void Return(T member);
	}
}

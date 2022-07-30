namespace AudioPool.Pool {
	
	public interface IPool<T> {
		T Request();
		void Return(T member);
	}
}

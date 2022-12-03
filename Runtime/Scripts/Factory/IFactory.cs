namespace JasonSkillman.AudioPool.Factory {
	
	public interface IFactory<out T> {
		T Create();
	}
}

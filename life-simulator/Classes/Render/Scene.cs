namespace life_simulator.Render {
	class Scene {
		public World World;

		public Scene(World world) {
			this.World = world;
		}

		public static Scene Create(World world) {
			return new Scene(world);
		}
	}
}

describe "color_enabled" do
  context "when set with RSpec.configure" do
    before do
      # color is disabled for non-tty output, so stub the output stream
      # to say it is tty, even though we're running this with cucumber
      RSpec.configuration.output_stream.stub(:tty?) { true }
    end

    it "is true" do
      RSpec.configuration.should be_color_enabled
    end
  end
end